namespace AutobotBlazor.Shared.Models
{
    public class Centre
    {
        public string uuid { get; set; } = string.Empty;
        public string referenceNumber { get; set; } = string.Empty;
        public string centerName { get; set; } = string.Empty;
        public int capacity { get; set; }
        public int backupCapacity { get; set; }
        public bool hasAutobot { get; set; }
        public bool hasUploadedCenterReport { get; set; }
        public bool hasUploadedComputerReport { get; set; }
        public bool hasUploadedExamReport { get; set; }
        public string state { get; set; } = string.Empty;
        public int totalRealizedNodes { get; set; }
    }
}
