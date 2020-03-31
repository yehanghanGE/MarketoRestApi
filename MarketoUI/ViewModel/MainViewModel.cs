using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketoApiLibrary;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using MarketoApiLibrary.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarketoUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        //private static object _lock = new object();
        #region properties
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private string _folderIds = "49792";// for testing, need to remove 30844"

        public string FolderIDs
        {
            get { return _folderIds; }
            set
            {
                _folderIds = value;
                RaisePropertyChanged();
            }
        }

        private string _savePath = $"D:\\DownloadedImageFromMarketo";

        public string SavePath
        {
            get { return _savePath; }
            set
            {
                _savePath = value;
                RaisePropertyChanged();
            }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        private int _folderStatus;

        public int FolderStatus
        {
            get { return _folderStatus; }
            set
            {
                _folderStatus = value;
                RaisePropertyChanged();
            }
        }

        private int _fileStatus;

        public int FileStatus
        {
            get { return _fileStatus; }
            set
            {
                _fileStatus = value;
                RaisePropertyChanged();
            }
        }

        private bool _hasSubFolders;

        public bool HasSubFolders
        {
            get { return _hasSubFolders; }
            set
            {
                _hasSubFolders = value;
                RaisePropertyChanged();
            }
        }

        private string _currentFolder = "FileStatus";

        public string CurrentFolder
        {
            get { return _currentFolder; }
            set
            {
                _currentFolder = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {
            this.Title = "MarketApiUI";
            StartCommand = new RelayCommand(Start);
            CancelCommand = new RelayCommand(Cancel);
        }

        #region commands
        public RelayCommand StartCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }
        #endregion

        #region methods
        private void Start()
        {
            cts = new CancellationTokenSource();
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            if (string.IsNullOrEmpty(FolderIDs) || string.IsNullOrEmpty(SavePath))
            {
                this.Status = $"FolderID or SavePath is invalid!";
                return;
            }

            this.Status = $"Loading api config...{Environment.NewLine}";
            ApiConfig apiConfig = ConfigurationProvider.LoadConfig();

            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Status += $"Loading Api Config execution time: { elapsedMs }...{Environment.NewLine}";

            List<string> folderIds = new List<string>();
            folderIds.Add(FolderIDs);

            Task task = Task.Run(() =>
            {
                DownLoadFile(apiConfig, FolderIDs, SavePath);
            });

        }

        private void Cancel()
        {
            cts.Cancel();
        }
        private async Task DownLoadFile(ApiConfig apiConfig, string folderId, string savePath)
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            List<string> statusLog = new List<string>();

            MarketoClient client = new MarketoClient(apiConfig.Host, apiConfig.ClientId, apiConfig.ClientSecret);
            List<string> folderIds = await GetAllFolderIDs(folderId, client);

            int processedFolderNums = 0;
            this.FolderStatus = 0;

            long elapsedMs;
            foreach (var id in folderIds)
            {
                this.CurrentFolder = id;
                Status += $"Reading folder {id}...{Environment.NewLine}";
                var saveRootPath = Path.Combine(savePath, id);
                List<MarketoFile> fileResults = await GetFileResults(client, id);
                Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
                progress.ProgressChanged += ReportProgress;
                CreateDir(saveRootPath);
                try
                {
                    await WriteFileToDiskParallelAsync(fileResults, saveRootPath, progress, cts.Token);
                }
                catch (OperationCanceledException e)
                {
                    Status += $"Downloading is cancelled...{Environment.NewLine}";
                    watch.Stop();
                    elapsedMs = watch.ElapsedMilliseconds;
                    Status += $"Total execution time: { elapsedMs }...{Environment.NewLine}";
                    return;
                }
                finally
                {
                    cts.Dispose();
                }
                //WriteFileToDisk(id, fileResults, saveRootPath, progress, cts.Token);

                Status += $"Done!{Environment.NewLine}";
                processedFolderNums += 1;
                this.FolderStatus = (processedFolderNums * 100) / folderIds.Count;
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Status += $"Total execution time: { elapsedMs }...{Environment.NewLine}";
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            this.FileStatus = e.PercentageComplete;
            ReportFileInfo(e.File.Name);
        }

        private async Task<List<string>> GetAllFolderIDs(string folderId, MarketoClient client)
        {
            List<string> folderIds = new List<string>();
            if (HasSubFolders)
            {
                Status += $"Getting sub folders...{Environment.NewLine}";
                folderIds = await GetSubFolderIDsAsync(client, folderId);
            }
            else
            {
                folderIds.Add(folderId);
            }

            return folderIds;
        }

        private void CreateDir(string saveRootPath)
        {
            if (Directory.Exists(saveRootPath)) return;
            Status += $"Creating folder { saveRootPath }...{Environment.NewLine}";
            Directory.CreateDirectory(saveRootPath);
        }

        private async Task<List<MarketoFile>> GetFileResults(MarketoClient client, string id)
        {
            List<MarketoFile> fileResults = new List<MarketoFile>();
            GetFilesResponse fileResult = await client.GetFiles(id, 0);
            if (fileResult?.Result != null)
            {
                fileResults.AddRange(fileResult.Result);
                int fileCounts = fileResult.Result.Count;
                int callTimes = 0;
                while (fileCounts >= 200)
                {
                    callTimes += 1;
                    //var clientNext = new MarketoClient(host, clientId, clientSecret);
                    GetFilesResponse fileResultNext = await client.GetFiles(id, callTimes * 200);
                    if (fileResultNext?.Result != null)
                    {
                        fileResults.AddRange(fileResultNext.Result);
                        fileCounts = fileResultNext.Result.Count;
                    }
                }
            }
            return fileResults;
        }

        private void WriteFileToDisk(string folderId, List<MarketoFile> fileResult, string saveRootPath, IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            ProgressReportModel report = new ProgressReportModel();
            int processedNum = 0;
            foreach (var file in fileResult)
            {
                string fileName = Path.Combine(saveRootPath, file.Name);
                FileDownloader.DownFile(file.Url, fileName);
                cancellationToken.ThrowIfCancellationRequested();
                processedNum += 1;
                report.PercentageComplete = (processedNum * 100) / fileResult.Count;
                report.File = file;
                progress.Report(report);
            }
        }

        private async Task WriteFileToDiskParallelAsync(List<MarketoFile> fileResult, string saveRootPath, IProgress<ProgressReportModel> progress, CancellationToken cancellationToken)
        {
            ProgressReportModel report = new ProgressReportModel();
            int processedNum = 0;

            var po = new ParallelOptions { CancellationToken = cancellationToken };

            await Task.Run(() =>
            {
                Parallel.ForEach(fileResult, po, (file) =>
                   {
                       string fileName = Path.Combine(saveRootPath, file.Name);
                       FileDownloader.DownFile(file.Url, fileName);

                       if (po.CancellationToken.IsCancellationRequested)
                       {
                           return;
                       }

                       processedNum += 1;
                       report.PercentageComplete = (processedNum * 100) / fileResult.Count;
                       report.File = file;
                       progress.Report(report);
                   });
            });
        }

        private void ReportFileInfo(string fileName)
        {
            Status += $"Downloading file: {fileName}...{Environment.NewLine}";
        }

        private List<string> GetSubFolderIDs(string host, string clientId, string clientSecret, string rootFolderId)
        {
            MarketoClient client = new MarketoClient(host, clientId, clientSecret);
            GetFoldersResponse result = client.GetFolders(rootFolderId).Result;
            List<string> folderIDs = new List<string>();
            if (result.Result != null)
            {
                foreach (MarketoFolder folder in result.Result)
                {
                    folderIDs.Add(folder.Id.ToString());
                }
            }
            return folderIDs;
        }

        private static async Task<List<string>> GetSubFolderIDsAsync(MarketoClient client, string rootFolderId)
        {
            //var client = new MarketoClient(apiConfig.Host, apiConfig.ClientId, apiConfig.ClientSecret);
            GetFoldersResponse result = await client.GetFolders(rootFolderId);
            List<string> folderIDs = new List<string>();
            if (result.Result == null) return folderIDs;
            folderIDs.AddRange(result.Result.Select(folder => folder.Id.ToString()));
            return folderIDs;
        }
        #endregion
    }
}