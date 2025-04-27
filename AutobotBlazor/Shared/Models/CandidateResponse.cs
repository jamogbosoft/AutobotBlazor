using System.ComponentModel.DataAnnotations;

namespace AutobotBlazor.Shared.Models
{
    public class CandidateResponse
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(3)]
        public string CentreId { get; set; } = string.Empty;
        [Required, StringLength(5)]
        public string SessionRef { get; set; } = string.Empty;
        [StringLength(10)]
        public string ExamDate { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;       
        [StringLength(14)]
        public string RegistrationNumber { get; set; } = string.Empty;       
        public string Status { get; set; } = string.Empty;
        public int TotalAttempted { get; set; }
        [StringLength(20)]
        public string StartTime { get; set; } = string.Empty;
        [StringLength(20)]
        public string EndTime{ get; set; } = string.Empty;        
        [StringLength(20)]       
        public string Duration { get; set; } = string.Empty;
        [StringLength(15)]
        public string IpAddress { get; set; } = string.Empty;
        public string PreviousHostIps { get; set; } = string.Empty;
        public bool Bvm { get; set; }
        [StringLength(1)]
        public string BvmStatus { get; set; } = string.Empty;
        public bool TimedOut { get; set; }
        public bool Connected { get; set; }
        public List<HostIP> HostIPs { get; set; } = new();
    }
}
