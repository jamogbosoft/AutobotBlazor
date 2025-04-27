using System.ComponentModel.DataAnnotations.Schema;

namespace AutobotBlazor.Shared.Models
{
    public class HostIP
    {
        public long Id { get; set; }
        public long CandidateResponseId { get; set; }
        public string Ip { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        //public ExamTime time { get; set; } = new ExamTime();
        //public ExamType _id { get; set; } = new ExamType();


        [ForeignKey("CandidateResponseId")]
        public CandidateResponse? CandidateResponse { get; set; }
    }
}
