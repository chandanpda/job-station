using System;

namespace JobStation.Parameters
{
    public class PaginationParams
    {
        public string Q { get; set; }
        public int Page { get; set; }
        public int RecordPerPage { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public string SortColumn { get; set; }
        public bool IsDownload { get; set; }
    }
}
