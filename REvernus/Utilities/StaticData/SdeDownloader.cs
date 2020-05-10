namespace REvernus.Utilities.StaticData
{
    using System;
    using System.IO;
    using System.Media;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Shell;

    using ICSharpCode.SharpZipLib.BZip2;
    using ICSharpCode.SharpZipLib.Core;

    using log4net;

    using REvernus.Utilites;
    using REvernus.Views.SimpleViews;

    public class SdeDownloader
    {
        // ReSharper disable once IdentifierTypo
        private const string FUZZWORK_LATEST_DB_PATH = @"http://www.fuzzwork.co.uk/dump/latest/eve.db.bz2";

        // ReSharper disable once PossibleNullReferenceException
        private readonly ILog _log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Window _window;

        public async Task DownloadLatestSde()
        {
            try
            {
                // Check to see if the Data folder has been made yet, if not, create it.
                if (!Directory.Exists(Paths.DataBaseFolderPath))
                    Directory.CreateDirectory(Paths.DataBaseFolderPath);

                if (Application.Current.Dispatcher != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _window = new Window
                        {
                            Title = "SDE Download",
                            Content = new SdeDownloadProgressView(),
                            Width = 500,
                            Height = 300,
                            WindowStartupLocation = WindowStartupLocation.CenterScreen,
                            TaskbarItemInfo = new TaskbarItemInfo { ProgressState = TaskbarItemProgressState.Normal }
                        };
                        _window.Show();
                        _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
                    });

                    // Download file
                    await DownloadFileAsync(FUZZWORK_LATEST_DB_PATH, Paths.CompressedSdeDataBasePath);

                    // Extract .bz2 file
                    await using (var outStream = File.Create(Path.Combine(Paths.DataBaseFolderPath, "eve.db")))
                    {
                        await using var fileStream = new FileStream(Paths.CompressedSdeDataBasePath, FileMode.Open,
                            FileAccess.ReadWrite, FileShare.ReadWrite);
                        await DecompressBz2(fileStream, outStream, false);

                        SystemSounds.Exclamation.Play();
                        Application.Current.Dispatcher.Invoke(() =>
                            _window.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None);
                    }

                    Application.Current.Dispatcher.Invoke(_window.Close);
                }
            }
            catch (Exception e)
            {
                if (Application.Current.Dispatcher != null)
                    Application.Current.Dispatcher.Invoke(_window.Close);
                _log.Error(e);
            }
        }

        private static async Task DecompressBz2(Stream inStream, Stream outStream, bool isStreamOwner)
        {
            await using var bzipInput = new BZip2InputStream(inStream) { IsStreamOwner = isStreamOwner };
            try
            {
                await Task.Run(() => StreamUtils.Copy(bzipInput, outStream, new byte[4096]));
                bzipInput.Dispose();
            }
            finally
            {
                if (isStreamOwner)
                    // inStream is closed by the BZip2InputStream if stream owner
                    outStream.Dispose();
            }
        }

        private static async Task DownloadFileAsync(string url, string filePath)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");
            using var response =
                await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            await using var streamToReadFrom = await response.Content.ReadAsStreamAsync();
            await using var streamToWriteTo = File.Open(filePath, FileMode.Create);
            await streamToReadFrom.CopyToAsync(streamToWriteTo);
        }
    }
}