using MarketoApiLibrary.Asset.Files.Response;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Response;

namespace MarketoUI.ViewModel
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public string FileName { get; set; }
        public FileResponse FileResponse { get; set; }
    }
}