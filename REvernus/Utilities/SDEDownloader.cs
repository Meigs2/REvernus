using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using ICSharpCode.SharpZipLib;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Shell;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using REvernus.Views.SimpleViews;

namespace REvernus.Utilities
{
    public class SdeDownloader
    {
        private readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // ReSharper disable once IdentifierTypo
        private readonly string _fuzzworkLatestDbPath = @"http://www.fuzzwork.co.uk/dump/latest/eve.db.bz2";
        private string _dataFolderPath => Path.Combine(Environment.CurrentDirectory, "Data");
        private readonly WebClient _webClient = new WebClient();
        private Window window;
        private SdeDownloadProgressView _windowView;

        public void DownloadLatestSde()
        {
            try
            {
                void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                {
                    _windowView.DownloadProgressBar.Value = e.ProgressPercentage;
                    window.TaskbarItemInfo.ProgressValue = e.ProgressPercentage/100d;
                }

                // Check to see if the Data folder has been made yet, if not, create it.
                if (!Directory.Exists(_dataFolderPath))
                {
                    Directory.CreateDirectory(_dataFolderPath);
                }

                window = new Window()
                {
                    Title = "Character Manager",
                    Content = new SdeDownloadProgressView(),
                    Width = 500,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.TaskbarItemInfo = new TaskbarItemInfo(){ ProgressState = TaskbarItemProgressState.Normal };
                // Prevent user from closing download window
                window.Closing += (sender, args) => { args.Cancel = true; };
                window.Show();
                _windowView = (SdeDownloadProgressView)window.Content;
                _windowView.TextBlock.Text = "Downloading the current SDE... This may take a while!\nThe client will freeze near the end\nso don't panic. This window will close after\n the download and unzip completes.";

                // Download file

                _webClient.DownloadProgressChanged += ClientDownloadProgressChanged;
                _webClient.Headers.Add("User-Agent: Other");
                _webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
                _webClient.DownloadFileAsync(new Uri(_fuzzworkLatestDbPath), Path.Combine(_dataFolderPath, "eve.db.bz2"));
            }
            catch (Exception e)
            {
                window.Close();
                Log.Error(e);
            }
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _webClient.Dispose();

            // Extract .bz2 file
            var fileStream = new FileStream(Path.Combine(_dataFolderPath, "eve.db.bz2"), FileMode.Open, FileAccess.Read, FileShare.Read);
            var outStream = File.Create(Path.Combine(_dataFolderPath, "eve.db"));

            Decompress(fileStream, outStream,false);

            SystemSounds.Exclamation.Play();
            window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;

            window.Close();
        }

        private void Decompress(Stream inStream, Stream outStream, bool isStreamOwner)
        {
            if (inStream == null || outStream == null)
            {
                throw new Exception("Null Stream");
            }

            try
            {
                using (BZip2InputStream bzipInput = new BZip2InputStream(inStream))
                {
                    bzipInput.IsStreamOwner = isStreamOwner;
                    StreamUtils.Copy(bzipInput, outStream, new byte[4096]);
                }
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
