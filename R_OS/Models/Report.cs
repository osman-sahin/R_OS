namespace R_OS.Models
{
    public enum ReportStatus { Preparing, Done}
    public class Report : BaseModel
    {
        public ReportStatus Status { get; set; } = 0;
        public string? FilePath { get; set; }
    }
}
