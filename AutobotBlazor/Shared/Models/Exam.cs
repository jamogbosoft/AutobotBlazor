namespace AutobotBlazor.Shared.Models
{
    public class Exam
    {
        public string centerUUID { get; set; } = string.Empty;
        public string centerReferenceNumber { get; set; } = string.Empty;
        public string centerName { get; set; } = string.Empty;
        public string centerState { get; set; } = string.Empty;
        public string examUUID { get; set; } = string.Empty;
        public string examName { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public int capacity { get; set; }
        public string startDateTime { get; set; } = string.Empty;
        public string endDateTime { get; set; } = string.Empty;
        public int connectedNodes { get; set; }
        public int durationInMinutes { get; set; }
        public int isUploaded { get; set; }
        public int numberOfQuestions { get; set; }
        public int permanentNetworkLossCount { get; set; }
        public int responseAnalysis0Count { get; set; }
        public int responseAnalysis25Count { get; set; }
        public int responseAnalysis50Count { get; set; }
        public int responseAnalysis75Count { get; set; }
        public int responseAnalysis100Count { get; set; }
        public int timeLeftInMinutes { get; set; }
        public int totalNetworkFailureCount { get; set; }
        public int totalNodesStarted { get; set; }
        public int totalNodesSubmitted { get; set; }
        public List<Node> nodesList { get; set; } = new List<Node>();

    }
}
