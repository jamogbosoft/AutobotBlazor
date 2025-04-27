namespace AutobotBlazor.Shared.Models
{
    public class ExternalCandidate
    {
        public string Date { get; set; } = string.Empty;
        public int Session { get; set; }
        public string CentreID { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty; 
        public string Timestamp { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; 
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string CurrentTime { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public int ResponsesCount { get; set; }
        public bool Bvm { get; set; }
        public string BvmStatus { get; set; } = string.Empty;
        public string? CandidateSystems { get; set; } 
        public bool TimedOut { get; set; }
        public bool Connected { get; set; }

        public string PreviousHostIps
        {
            get
            {
                if (CandidateSystems is null) { return string.Empty; }
                string json = "[" + CandidateSystems
                    .Replace(" / ", "")
                    .Replace("</div><div>", "\"}, ")
                    .Replace("<div>", "")
                    .Replace("</div>", "")
                    .Replace("<br/>", "")
                    .Replace("<br />", "")
                    .Replace("<b>", "{\"Ip\": \"")
                    .Replace("</b>", "\", \"Time\": \"")
                    + "\"}]";
                return json;

            }
        }
        public string Duration
        {
            get
            {
                if (StartTime is null || EndTime is null)
                {
                    return "";
                }
                TimeOnly result;
                TimeOnly start = TimeOnly.TryParse(StartTime, out result) ? result : new TimeOnly();
                TimeOnly end = TimeOnly.TryParse(EndTime, out result) ? result : new TimeOnly();

                var duration = end - start;
                return duration.ToString();
            }
        }
    }
}
