using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketoApiLibrary;
using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Model;
using MarketoRestApiLibrary.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MarketoUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        //private static object _lock = new object();
        #region properties
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        private string folderIds = "30844";// for testing, need to remove

        public string FolderIDs
        {
            get { return folderIds; }
            set
            {
                folderIds = value;
                RaisePropertyChanged();
            }
        }

        private string savePath = $"D:\\DownloadedImageFromMarketo";

        public string SavePath
        {
            get { return savePath; }
            set
            {
                savePath = value;
                RaisePropertyChanged();
            }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged();
            }
        }

        private bool hasSubFolders;

        public bool HasSubFolders
        {
            get { return hasSubFolders; }
            set
            {
                hasSubFolders = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public MainViewModel()
        {
            this.Title = "MarketApiUI";
            StartCommand = new RelayCommand(Start);
        }

        #region commands
        public RelayCommand StartCommand { get; set; }
        #endregion

        #region methods
        private void Start()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (string.IsNullOrEmpty(FolderIDs) || string.IsNullOrEmpty(SavePath))
            {
                this.Status = $"FolderID or SavePath is invalid!";
                return;
            }

            this.Status = $"Loading api config...{Environment.NewLine}";
            var apiConfig = ConfigurationProvider.LoadConfig();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Status += $"Loading Api Config execution time: { elapsedMs }...{Environment.NewLine}";

            var folderIds = new List<string>();
            folderIds.Add(FolderIDs);

            var task = Task.Run(() =>
            {
                DownFile(apiConfig, FolderIDs, SavePath);
            });

        }
        private async Task DownFile(ApiConfig apiConfig, string folderId, string savePath)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var statusLog = new List<string>();

            var client = new MarketoClient(apiConfig.Host, apiConfig.ClientId, apiConfig.ClientSecret);
            var folderIds = await GetAllFolderIDs(folderId, client);

            foreach (var id in folderIds)
            {
                Status += $"Reading folder {id}...{Environment.NewLine}";
                var saveRootPath = Path.Combine(savePath, id);
                var fileResults = await GetFileResults(client, id);
                Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
                CreatDir(saveRootPath);
                await WriteFileToDiskParallelAsync(id, fileResults, saveRootPath);
                Status += $"Done!{Environment.NewLine}";
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Status += $"Total execution time: { elapsedMs }...{Environment.NewLine}";
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

        private void CreatDir(string saveRootPath)
        {
            if (!Directory.Exists(saveRootPath))
            {
                Status += $"Creating folder { saveRootPath }...{Environment.NewLine}";
                Directory.CreateDirectory(saveRootPath);
            }
        }

        private async Task<List<MarketoFile>> GetFileResults(MarketoClient client, string id)
        {
            List<MarketoFile> fileResults = new List<MarketoFile>();
            GetFilesResponse fileResult = await client.GetFiles(id, 0);
            if (fileResult?.Result != null)
            {
                fileResults.AddRange(fileResult.Result);
                var fileCounts = fileResult.Result.Count;
                int call_times = 0;
                while (fileCounts >= 200)
                {
                    call_times += 1;
                    //var clientNext = new MarketoClient(host, clientId, clientSecret);
                    GetFilesResponse fileResultNext = await client.GetFiles(id, call_times * 200);
                    if (fileResultNext?.Result != null)
                    {
                        fileResults.AddRange(fileResultNext.Result);
                        fileCounts = fileResultNext.Result.Count;
                    }
                }
            }
            return fileResults;
        }

        private void WriteFileToDisk(string folderId, GetFilesResponse fileResult, string saveRootPath)
        {
            foreach (var file in fileResult?.Result)
            {
                var fileName = Path.Combine(saveRootPath, file.Name);
                ReportFileInfo(folderId, file);
                FileDownloader.DownFile(file.Url, fileName);
            }
        }

        private async Task WriteFileToDiskParallelAsync(string folderId, List<MarketoFile> fileResult, string saveRootPath)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach<MarketoFile>(fileResult, (file) =>
                {
                    var fileName = Path.Combine(saveRootPath, file.Name);
                    FileDownloader.DownFileAsync(file.Url, fileName);
                    ReportFileInfo(folderId, file);
                });
            });
        }

        private void ReportFileInfo(string folderId, MarketoFile file)
        {
            Status += $" { folderId }: Downloading file: {file.Name}...{Environment.NewLine}";
        }

        private List<string> GetSubFolderIDs(string host, string clientId, string clientSecret, string rootFolderId)
        {
            var client = new MarketoClient(host, clientId, clientSecret);
            var result = client.GetFolders(rootFolderId).Result;
            var folderIDs = new List<string>();
            if (result.Result != null)
            {
                foreach (var folder in result.Result)
                {
                    folderIDs.Add(folder.Id.ToString());
                }
            }
            return folderIDs;
        }

        private async Task<List<string>> GetSubFolderIDsAsync(MarketoClient client, string rootFolderId)
        {
            //var client = new MarketoClient(apiConfig.Host, apiConfig.ClientId, apiConfig.ClientSecret);
            var result = await client.GetFolders(rootFolderId);
            var folderIDs = new List<string>();
            if (result.Result != null)
            {
                foreach (var folder in result.Result)
                {
                    folderIDs.Add(folder.Id.ToString());
                }
            }
            return folderIDs;
        }
        #endregion
    }
}