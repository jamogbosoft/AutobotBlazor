using System.ComponentModel.DataAnnotations.Schema;

namespace AutobotBlazor.Shared.Models
{
    public  class ExamType
    {
        public long Id { get; set; }
        
        public long HostIPId { get; set; }
        public string oid { get; set; } = string.Empty;

        [ForeignKey(nameof(HostIPId))]
        public HostIP? HostIP { get; set; }
    }
}
