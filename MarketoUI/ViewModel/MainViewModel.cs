using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketoApiLibrary;
using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Model;
using MarketoRestApiLibrary.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace MarketoUI.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            this.Title = "MarketApiUI";
            this.StartCommand = new RelayCommand(Start);
        }

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



        public RelayCommand StartCommand { get; set; }

        private void Start()
        {
            if (string.IsNullOrEmpty(FolderIDs) || string.IsNullOrEmpty(SavePath))
            {
                MessageBox.Show("FolderID or SavePath is invalid!");
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
                DownFile(host, clientId, clientSecret, folderIds, SavePath);
            });
        }

        private void DownFile(string host, string clientId, string clientSecret, List<string> folderIds, string savePath)
        {
            var client = new MarketoClient(host, clientId, clientSecret);
            foreach (var folderId in folderIds)
            {
                this.Status = "Reading folder " + folderId + "...";
                GetFilesResponse fileResult = client.GetFiles<GetFilesResponse>(folderId, "0");
                var saveRootPath = Path.Combine(savePath, folderId);

                if (fileResult?.Result != null)
                {
                    if (!Directory.Exists(saveRootPath))
                    {
                        this.Status = "Creating folder " + saveRootPath + "...";
                        Directory.CreateDirectory(saveRootPath);
                    }
                    WriteFileToDisk(fileResult, saveRootPath);
                    if (fileResult.Result.Count >= 200)
                    {
                        var client200 = new MarketoClient(host, clientId, clientSecret);
                        GetFilesResponse fileResult200 = client200.GetFiles<GetFilesResponse>(folderId, "200");
                        if (fileResult200?.Result != null)
                        {
                            WriteFileToDisk(fileResult200, saveRootPath);
                        }
                    }
                }
                this.Status = "Done!";
            }

        }
        private void WriteFileToDisk(GetFilesResponse fileResult, string saveRootPath)
        {
            foreach (var file in fileResult?.Result)
            {
                var fileName = Path.Combine(saveRootPath, file.Name);
                this.Status = "Downloading file " + file.Name + "...";
                FileDownloader.DownFile(file.Url, fileName);
                Console.WriteLine(file?.Url);
            }
        }
    }
}