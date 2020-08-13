namespace Marketo.ApiLibrary.Leads.BulkExportLeads.Request
{
    public class ExportLeadFilter
    {
        public DateRange CreateAt { get; set; }
        public DateRange UpdatedAt { get; set; }
        public int SmartListId { get; set; }
        public string SmartListName { get; set; }
        public int StaticListId { get; set; }
        public string StaticListName { get; set; }
    }
}