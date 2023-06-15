using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutobotBlazor.Shared.Models
{
    public class HostIP
    {
        public long Id { get; set; }
        public long CandidateResponseId { get; set; }
        public string ip { get; set; } = string.Empty;
        public ExamTime time { get; set; } = new ExamTime();
        public ExamType _id { get; set; } = new ExamType();


        [ForeignKey("CandidateResponseId")]
        public CandidateResponse? CandidateResponse { get; set; }
    }
}
