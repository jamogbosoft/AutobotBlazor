namespace AutobotBlazor.Shared.Models
{
    public class ExternalCentre
    {
        public string Date { get; set; } = string.Empty;
        public int Session { get; set; } 
        public string CentreID { get; set; } = string.Empty;
        public long CID
        {
            get
            {
                return long.TryParse(CentreID, out long id) ? id : 0;
            }
        }
    }
}
