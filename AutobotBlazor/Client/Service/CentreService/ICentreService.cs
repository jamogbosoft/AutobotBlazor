using AutobotBlazor.Shared.Models;

namespace AutobotBlazor.Client.Service.CentreService
{
    public interface ICentreService
    {
        List<Centre> CentresList { get; set; }
        Task GetCentres();        
    }
}
