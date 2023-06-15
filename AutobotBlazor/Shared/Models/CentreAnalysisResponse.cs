namespace AutobotBlazor.Shared.Models
{
    public class CentreAnalysisResponse
    {
        public string CentreId { get; set; } = string.Empty;
        public string SessionRef { get; set; } = string.Empty;
        public string ExamDate { get; set; } = string.Empty;
        public int NumberOfCandidates { get; set; }
        public int Category_A_Count { get; set; }
        public int Category_B_Count { get; set; }
        public int Category_C_Count { get; set; }
        public int Category_D_Count { get; set; }
        public int Category_E_Count { get; set; }
    }
}
