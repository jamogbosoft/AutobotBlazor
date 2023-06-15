namespace AutobotBlazor.Shared.Models
{
    public  class Node
    {
        public string candidateName { get; set; } = string.Empty;
        public string centerUUID { get; set; } = string.Empty;
        public string examName { get; set; } = string.Empty;
        public string examUUID { get; set; } = string.Empty;
        public string nodeUUID { get; set; } = string.Empty;
        public string ipAddress { get; set; } = string.Empty;
        public string startTime { get; set; } = string.Empty;
        public string endTime { get; set; } = string.Empty;
        public string connectedStatus { get; set; } = string.Empty;
        public string cpuUsage { get; set; } = string.Empty;
        public string dataReceived { get; set; } = string.Empty;
        public string dataSent { get; set; } = string.Empty;
        public string endStatus { get; set; } = string.Empty;
        public int lastUpdatedMinutesAgo { get; set; }       
        public string ramUsage { get; set; } = string.Empty;
        public string registrationNumber { get; set; } = string.Empty;
        public int responseCount { get; set; } 
        public string startStatus { get; set; } = string.Empty;                
        public string subject { get; set; } = string.Empty;
        public int submissionCount { get; set; }
        public int timeLeftInMinutes { get; set; }             
    }
}
