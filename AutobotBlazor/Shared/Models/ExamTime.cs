using System.ComponentModel.DataAnnotations.Schema;

namespace AutobotBlazor.Shared.Models
{
    public class ExamTime
    {
        public long Id { get; set; }
        public long HostIPId { get; set; }
        public string date { get; set; } = string.Empty;
        public string time { get; set; } = string.Empty;

        [ForeignKey(nameof(HostIPId))]
        public HostIP? HostIP { get; set; }
    }
}
