using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketoApiLibrary;
using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Model;
using MarketoRestApiLibrary.Provider;
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

        private string folderIds;

        public string FolderIDs
        {
            get { return folderIds; }
            set
            {
                folderIds = value;
                RaisePropertyChanged();
            }
        }

        private string savePath;

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
            this.StartCommand = new RelayCommand(Start);
            //Application.Current.Dispatcher.Invoke(() => BindingOperations.EnableCollectionSynchronization(Status, _lock));
            //BindingOperations.EnableCollectionSynchronization(Status, _lock);
        }

        #region commands
        public RelayCommand StartCommand { get; set; }
        #endregion

        #region methods
        private void Start()
        {
            if (string.IsNullOrEmpty(FolderIDs) || string.IsNullOrEmpty(SavePath))
            {
                this.Status = "FolderID or SavePath is invalid!";
                return;
            }

            this.Status = "Loading api config...";
            var apiConfig = ConfigurationProvider.LoadConfig();
            var host = apiConfig.Host;
            var clientId = apiConfig.ClientId;
            var clientSecret = apiConfig.ClientSecret;

            var folderIds = new List<string>();
            folderIds.Add(FolderIDs);

            var task = Task.Run(() =>
            {
                DownFile(host, clientId, clientSecret, FolderIDs, SavePath);
            });
        }
        private void DownFile(string host, string clientId, string clientSecret, string folderId, string savePath)
        {
            var statusLog = new List<string>();
            List<string> folderIds = new List<string>();
            if (HasSubFolders)
            {
                Status += "\nGetting sub folders...";
                folderIds = GetSubFolderIDs(host, clientId, clientSecret, folderId);
            }
            else
            {
                folderIds.Add(folderId);
            }

            var client = new MarketoClient(host, clientId, clientSecret);
            foreach (var id in folderIds)
            {
                Status += "\nReading folder " + id + "...";
                GetFilesResponse fileResult = client.GetFiles(id, "0").Result;
                var saveRootPath = Path.Combine(savePath, id);

                if (fileResult?.Result != null)
                {
                    if (!Directory.Exists(saveRootPath))
                    {
                        Status += "\nCreating folder " + saveRootPath + "...";
                        Directory.CreateDirectory(saveRootPath);
                    }
                    WriteFileToDisk(id, fileResult, saveRootPath);
                    if (fileResult.Result.Count >= 200)
                    {
                        var client200 = new MarketoClient(host, clientId, clientSecret);
                        GetFilesResponse fileResult200 = client200.GetFiles(id, "200").Result;
                        if (fileResult200?.Result != null)
                        {
                            WriteFileToDisk(id, fileResult200, saveRootPath);
                        }
                    }
                }
                Status += "\nDone!";
            }

        }
        private void WriteFileToDisk(string folderId, GetFilesResponse fileResult, string saveRootPath)
        {
            foreach (var file in fileResult?.Result)
            {
                var fileName = Path.Combine(saveRootPath, file.Name);
                this.Status += "\n" + folderId + ": Downloading file " + file.Name + "...";
                FileDownloader.DownFile(file.Url, fileName);
            }
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
        #endregion
    }
}