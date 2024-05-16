using System.ComponentModel.DataAnnotations;

namespace AutobotBlazor.Shared.Models
{
    public class CandidateResponse
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(3)]
        public string CentreId { get; set; } = string.Empty;
        [StringLength(10)]
        public string ExamDate { get; set; } = string.Empty;
        public string PreviousHostIps { get; set; } = string.Empty;
        [StringLength(14)]
        public string RegistrationNumber { get; set; } = string.Empty;
        [Required, StringLength(5)]
        public string SessionRef { get; set; } = string.Empty;
        public int TotalAttempted { get; set; }
        [StringLength(12)]
        public string StartTime { get; set; } = string.Empty;
        [StringLength(12)]
        public string EndTime{ get; set; } = string.Empty;
        
        [StringLength(12)]       
        public string Duration { get; set; } = string.Empty;
        public List<HostIP> HostIPs { get; set; } = new();
    }
}
