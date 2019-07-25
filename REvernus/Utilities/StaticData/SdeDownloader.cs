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
        private readonly WebClient _webClient;
        private Window _window;
        private SdeDownloadProgressView _windowView;

        public SdeDownloader()
        {
            _webClient = new WebClient();
        }

        public async Task DownloadLatestSde()
        {
            try
            {
                void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                        {
                            _windowView.DownloadProgressBar.Value = e.ProgressPercentage;
                            _window.TaskbarItemInfo.ProgressValue = e.ProgressPercentage / 100d;
                        });
                }

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
                });

                // Download file

                _webClient.DownloadProgressChanged += ClientDownloadProgressChanged;
                _webClient.Headers.Add("User-Agent: Other");
                await Task.Run(() =>
                    _webClient.DownloadFile(new Uri(_fuzzworkLatestDbPath), Paths.CompressedSdeDataBasePath));

                _webClient.Dispose();

                // Extract .bz2 file
                await using (var outStream = File.Create(Path.Combine(Paths.DataBaseFolderPath, "eve.db")))
                {
                    await using var fileStream = new FileStream(Path.Combine(Paths.DataBaseFolderPath, "eve.db.bz2"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    await DecompressBz2(fileStream, outStream, false);

                    SystemSounds.Exclamation.Play();
                    _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
                }

                Application.Current.Dispatcher.Invoke(_window.Close);
            }
            catch (Exception e)
            {
                Application.Current.Dispatcher.Invoke(_window.Close);
                _log.Error(e);
            }
        }

        private static async Task DecompressBz2(Stream inStream, Stream outStream, bool isStreamOwner)
        {
            await using var bzipInput = new BZip2InputStream(inStream) {IsStreamOwner = isStreamOwner};
            try
            {
                await Task.Run(() => StreamUtils.Copy(bzipInput, outStream, new byte[4096]));
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
