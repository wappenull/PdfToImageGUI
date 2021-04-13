using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfToImageGUI
{
    public partial class MainForm : Form
    {
        WorkerParams m_Wp;

        public MainForm( )
        {
            InitializeComponent( );

            backgroundWorker1.DoWork += ConvertWorker.BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
        }

        /* Form events ///////////////////////////////////////////*/

        private void MainForm_Load( object sender, EventArgs e )
        {
            this.Text += $"| V{Application.ProductVersion}";
            
            // Default options
            dpiSelect.SelectedIndex = 1; // 72
            formatSelect.SelectedIndex = 1; // jpg 50%
            _UpdateEffectivePath( );
        }

        private void Form1_DragDrop( object sender, DragEventArgs e )
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if( files.Length > 0 )
            {
                SetInputPath( files[0] );
                Debug.WriteLine( "file is here! " + files[0] );
            }
        }

        private void Form1_DragEnter( object sender, DragEventArgs e )
        {
            // Display nice icon
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) e.Effect = DragDropEffects.Copy;
        }

        private void OpenUrlFromLinkLabel( object sender, LinkLabelLinkClickedEventArgs e )
        {
            LinkLabel lb = (LinkLabel)sender;
            string url;
            if( e.Link.LinkData != null )
                url = e.Link.LinkData.ToString( );
            else
                url = lb.Text;

            if( !url.Contains( "://" ) )
                url = "https://" + url;

            var si = new ProcessStartInfo(url);
            si.UseShellExecute = true;
            Process.Start( si );
        }

        private void goButton_Click( object sender, EventArgs e )
        {
            Convert( );
        }

        private void OnUiStateChanged( object sender, EventArgs e )
        {
            _UpdateEffectivePath( );
        }

        private void browseInput_Click( object sender, EventArgs e )
        {
            var ofd = new OpenFileDialog( );
            ofd.Filter           = "PDF file|*.pdf";
            ofd.RestoreDirectory = true;

            if( ofd.ShowDialog( ) == DialogResult.OK )
            {
                SetInputPath( ofd.FileName );
            }
        }

        private void browseOutput_Click( object sender, EventArgs e )
        {
            _UpdateEffectivePath( );
            string forecastFilename = m_Wp.GetFullOutputPathForPage( 1 );

            var sfd              = new SaveFileDialog( );
            sfd.InitialDirectory = outputPath.Text;
            sfd.FileName         = forecastFilename;
            sfd.DefaultExt       = GetUsingExt( );
            sfd.Filter           = "Image file|*.*";
            sfd.ValidateNames    = false;
            sfd.CheckFileExists  = false;
            sfd.CheckPathExists  = true;
            sfd.RestoreDirectory = true;

            if( sfd.ShowDialog( ) == DialogResult.OK )
            {
                outputPath.Text = Path.GetDirectoryName( sfd.FileName );
                _UpdateEffectivePath( );
            }
        }

        /* Worker /////////////////////////////////////////////*/

        WorkingDialog m_Popup;

        public void SetStatusText( string txt )
        {
            // Forward to text box
            if( m_Popup != null )
                m_Popup.SetStatusText( txt );
        }

        internal void NotifyAbort( )
        {
            if( backgroundWorker1.IsBusy )
                backgroundWorker1.CancelAsync( );
        }

        private void BackgroundWorker1_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            SetStatusText( (string)e.UserState );
        }

        private void BackgroundWorker1_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            m_Popup.Close( ); // Calling close might dispose, so create new one next time
            m_Popup = null;

            if( e.Cancelled )
                InfoMsg( "User cancelled operation. Are you joking to me?" );
            else
                InfoMsg( $"{e.Result}\nConversion is done." );
        }

        /* Interface //////////////////////////////////////////////////*/

        string GetUsingExt( )
        {
            switch( formatSelect.SelectedIndex )
            {
                case 0: // JPG 80%
                case 1: // JPG 50%
                    return "jpg";
                default:
                    return "png";
            }
        }

        int GetUsingDpi( )
        {
            switch( dpiSelect.SelectedIndex )
            {
                case 0: return 50;
                default:
                case 1: return 72;
                case 2: return 200;
                case 3: return 300;
            }
        }

        private void SetInputPath( string v )
        {
            inputPath.Text = v;
            _UpdateEffectivePath( );
        }

        string GetFilenamePrefix( )
        {
            string filename = "";
            if( appendSourceOption.Checked )
                filename = $"{Path.GetFileNameWithoutExtension( inputPath.Text )}_";
            return filename;
        }

        private void _UpdateEffectivePath( )
        {
            outputPath.ReadOnly = sameOutputSourceOption.Checked;
            browseOutput.Enabled = !sameOutputSourceOption.Checked;

            if( sameOutputSourceOption.Checked )
            {
                if( !string.IsNullOrEmpty( inputPath.Text ) )
                    outputPath.Text = Path.GetDirectoryName( inputPath.Text );
                else
                    outputPath.Text = "";
            }

            // Filename decision is moved to WorkerParams
            if( m_Wp == null )
                m_Wp = new WorkerParams( );

            m_Wp.inputFile    = inputPath.Text;
            m_Wp.outputDir    = outputPath.Text;
            m_Wp.outputPrefix = GetFilenamePrefix( );
            m_Wp.outputExt    = GetUsingExt( );
            m_Wp.dpi          = GetUsingDpi( );
            m_Wp.outputFormat = (OutputFormat)formatSelect.SelectedIndex;

            if( string.IsNullOrEmpty( outputPath.Text ) )
                outputPathPreview.Text = "Select input file";
            else
                outputPathPreview.Text = m_Wp.GetFullOutputPathForPage( 1 );
        }

        public void Convert( )
        {
            if( !File.Exists( inputPath.Text ) )
            {
                InfoMsg( $"Input file is not exist\n{inputPath.Text}\nDeal with it." );
                return;
            }

            _UpdateEffectivePath( );
            // Check if file already exists
            if( File.Exists( outputPathPreview.Text ) )
            {
                InfoMsg( $"Looks like there is file exists at\n{outputPathPreview.Text}\nPlease resolve this manually, for safety reason (loss of data), program will not continue." );
                return;
            }

            // Try create directory once
            if( !Directory.Exists( outputPath.Text ) )
                Directory.CreateDirectory( outputPath.Text );

            if( !Directory.Exists( outputPath.Text ) )
            {
                ErrorMsg( $"Save path \n{outputPath.Text}\nis invalid" );
                return;
            }

            if( m_Popup == null )
                m_Popup = new WorkingDialog( this );

            backgroundWorker1.RunWorkerAsync( m_Wp );

            m_Popup.ShowDialog( this ); // ShowDialog is blocking call
        }

        public bool AskYesNo( string v )
        {
            return MessageBox.Show( this, v, "Make decision wisely.", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes;
        }

        public void ErrorMsg( string v )
        {
            MessageBox.Show( this, v, "Are you JOKING with me?", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        public void InfoMsg( string v )
        {
            MessageBox.Show( this, v, "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }

    enum OutputFormat
    {
        Jpeg80,
        Jpeg50,
        Png
    }

}
