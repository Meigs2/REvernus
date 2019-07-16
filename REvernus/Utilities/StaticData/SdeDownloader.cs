using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Net;
using System.Windows;
using System.Windows.Shell;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Core;
using REvernus.Views.SimpleViews;

namespace REvernus.Utilities.StaticData
{
    public class SdeDownloader
    {
        private readonly log4net.ILog _log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // ReSharper disable once IdentifierTypo
        private readonly string _fuzzworkLatestDbPath = @"http://www.fuzzwork.co.uk/dump/latest/eve.db.bz2";
        private readonly WebClient _webClient;
        private Window _window;
        private SdeDownloadProgressView _windowView;
        private bool _isDownloadComplete;

        public SdeDownloader()
        {
            _webClient = new WebClient();
        }

        public void DownloadLatestSde()
        {
            try
            {
                void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                {
                    _windowView.DownloadProgressBar.Value = e.ProgressPercentage;
                    _window.TaskbarItemInfo.ProgressValue = e.ProgressPercentage / 100d;
                }

                // Check to see if the Data folder has been made yet, if not, create it.
                if (!Directory.Exists(Paths.DataBaseFolderPath))
                {
                    Directory.CreateDirectory(Paths.DataBaseFolderPath);
                }

                _window = new Window()
                {
                    Title = "Character Manager",
                    Content = new SdeDownloadProgressView(),
                    Width = 500,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                _window.TaskbarItemInfo = new TaskbarItemInfo() { ProgressState = TaskbarItemProgressState.Normal };
                _window.Closing += Window_Closing;
                _window.Show();
                _windowView = (SdeDownloadProgressView)_window.Content;
                _windowView.TextBlock.Text = "Downloading the current SDE... This may take a while!\nThe client will freeze near the end\nso don't panic. This window will close after\n the download and unzip completes.";

                // Download file

                _webClient.DownloadProgressChanged += ClientDownloadProgressChanged;
                _webClient.Headers.Add("User-Agent: Other");
                _webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
                _webClient.DownloadFileAsync(new Uri(_fuzzworkLatestDbPath), Paths.CompressedSdeDataBasePath);
            }
            catch (Exception e)
            {
                _window.Close();
                _log.Error(e);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_isDownloadComplete) return;

            SystemSounds.Asterisk.Play();
            e.Cancel = true;
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _webClient.Dispose();

            // Extract .bz2 file
            using (var outStream = File.Create(Path.Combine(Paths.DataBaseFolderPath, "eve.db")))
            {
                using var fileStream = new FileStream(Path.Combine(Paths.DataBaseFolderPath, "eve.db.bz2"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                DecompressBz2(fileStream, outStream, false);

                SystemSounds.Exclamation.Play();
                _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            }

            _isDownloadComplete = true;
            _window.Close();
        }

        private static void DecompressBz2(Stream inStream, Stream outStream, bool isStreamOwner)
        {
            try
            {
                using BZip2InputStream bzipInput = new BZip2InputStream(inStream) {IsStreamOwner = isStreamOwner};
                StreamUtils.Copy(bzipInput, outStream, new byte[4096]);
                bzipInput.Dispose();
            }
            finally
            {
                if (isStreamOwner)
                {
                    // inStream is closed by the BZip2InputStream if stream owner
                    outStream.Dispose();
                }
            }
        }
    }
}
