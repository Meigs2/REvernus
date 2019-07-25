using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Net;
using System.Threading.Tasks;
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
        private Window _window;
        private SdeDownloadProgressView _windowView;

        public async Task DownloadLatestSde()
        {
            try
            {
                var webClient = new WebClient();
                // Check to see if the Data folder has been made yet, if not, create it.
                if (!Directory.Exists(Paths.DataBaseFolderPath))
                {
                    Directory.CreateDirectory(Paths.DataBaseFolderPath);
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    _window = new Window
                    {
                        Title = "Character Manager",
                        Content = new SdeDownloadProgressView(),
                        Width = 500,
                        Height = 300,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                        TaskbarItemInfo = new TaskbarItemInfo() {ProgressState = TaskbarItemProgressState.Normal}
                    };
                    _window.Show();
                    _windowView = (SdeDownloadProgressView) _window.Content;
                    _windowView.TextBlock.Text = "Downloading the current SDE... This may take a while!";
                    _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
                });

                // Download file

                webClient.Headers.Add("User-Agent: Other");
                await webClient.DownloadFileTaskAsync(new Uri(_fuzzworkLatestDbPath), Paths.CompressedSdeDataBasePath);

                webClient.Dispose();

                // Extract .bz2 file
                await using (var outStream = File.Create(Path.Combine(Paths.DataBaseFolderPath, "eve.db")))
                {
                    await using var fileStream = new FileStream(Paths.CompressedSdeDataBasePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    DecompressBz2(fileStream, outStream, false);

                    SystemSounds.Exclamation.Play();
                    Application.Current.Dispatcher.Invoke(() =>
                        _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None);
                }

                Application.Current.Dispatcher.Invoke(_window.Close);
            }
            catch (Exception e)
            {
                Application.Current.Dispatcher.Invoke(_window.Close);
                _log.Error(e);
            }
        }

        private static void DecompressBz2(Stream inStream, Stream outStream, bool isStreamOwner)
        {
            using var bzipInput = new BZip2InputStream(inStream) {IsStreamOwner = isStreamOwner};
            try
            {
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
