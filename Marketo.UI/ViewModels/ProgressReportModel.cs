using Marketo.ApiLibrary.Asset.Files.Response;

namespace Marketo.UI.ViewModels
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public string FileName { get; set; }
        public FileResponse FileResponse { get; set; }
    }
}