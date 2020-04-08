using MarketoApiLibrary.Asset.Files.Response;

namespace MarketoUI.ViewModels
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public string FileName { get; set; }
        public FileResponse FileResponse { get; set; }
    }
}