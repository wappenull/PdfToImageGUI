using PdfiumViewer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace PdfToImageGUI
{
    static class ConvertWorker
    {
        public static void BackgroundWorker1_DoWork( object sender, DoWorkEventArgs e )
        {
            BackgroundWorker worker = sender as BackgroundWorker;

#if false // This was for testing
            for( int i=0 ; i<100 ; i++ )
            {
                worker.ReportProgress( i, "Doing something " + i );
                System.Threading.Thread.Sleep( 100 );

                if( worker.CancellationPending )
                {
                    e.Cancel = true;
                    break;
                }
            }
#endif
            _ConvertImpl( worker, e );
        }

        static void _ConvertImpl( BackgroundWorker worker, DoWorkEventArgs e )
        {
            WorkerParams wp = e.Argument as WorkerParams;
            int dpi = wp.dpi;

            int quality = 100;
            switch( wp.outputFormat )
            {
                case OutputFormat.Jpeg80:
                    quality = 80; break;
                case OutputFormat.Jpeg50:
                    quality = 50; break;
            }
            var jpegEncoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            var jpegParams = new EncoderParameters(1);
            jpegParams.Param[0] = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, quality );
            
            try
            {
                using( var document = PdfDocument.Load( wp.inputFile ) )
                {
                    var pageCount = document.PageCount;
                    for( int i = 0; i < pageCount; i++ )
                    {
                        string outputPath = wp.GetFullOutputPathForPage( i );
                        worker.ReportProgress( 0, $"Page {i} to\n{outputPath}" );

                        using( Image image = document.Render( i, dpi, dpi, PdfRenderFlags.CorrectFromDpi ) )
                        {
                            switch( wp.outputFormat )
                            {
                                case OutputFormat.Jpeg80:
                                case OutputFormat.Jpeg50:
                                    image.Save( outputPath, jpegEncoder, jpegParams );
                                    break;
                                default:
                                case OutputFormat.Png:
                                    image.Save( outputPath, ImageFormat.Png );
                                    break;
                            }
                        }

                        if( worker.CancellationPending )
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                e.Result = ex.Message;
            }

            jpegParams.Dispose( );
        }
    }

    class WorkerParams
    {
        public OutputFormat outputFormat;
        public int dpi;
        public string inputFile;
        public string outputDir;
        public string outputPrefix;
        public string outputExt;

        public string GetFullOutputPathForPage( int page )
        {
            return Path.Combine( outputDir, GetFilenameForPage( page ) );
        }

        private string GetFilenameForPage( int page )
        {
            // D3 = Decimal 3 digit 001 002 003 ...
            return $"{outputPrefix}{page:D3}.{outputExt}";
        }
    }
}
