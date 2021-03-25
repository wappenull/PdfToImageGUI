using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfToImageGUI
{
    partial class WorkingDialog : Form
    {
        readonly MainForm main;

        public WorkingDialog( MainForm m )
        {
            main = m;
            InitializeComponent( );
        }

        private void WorkingDialog_Load( object sender, EventArgs e )
        {
            statusText.Text = "Waiting...";
        }

        public void SetStatusText( string txt )
        {
            statusText.Text = txt;
        }

        private void okButton_Click( object sender, EventArgs e )
        {
            main.NotifyAbort( );
        }
    }
}
