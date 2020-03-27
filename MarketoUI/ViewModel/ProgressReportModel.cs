using MarketoRestApiLibrary.Model;

namespace MarketoUI.ViewModel
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public string FileName { get; set; }
        public MarketoFile File { get; set; }
    }
}