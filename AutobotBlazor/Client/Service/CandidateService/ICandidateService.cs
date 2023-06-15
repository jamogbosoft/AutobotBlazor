using AutobotBlazor.Shared.Services;

namespace AutobotBlazor.Client.Service.CandidateService
{
    public interface ICandidateService
    {
        string Message { get; set; }
        List<CandidateResponse> Candidates { get; set; }
        List<CentreAnalysisResponse> MultipleLogins { get; set; }
        List<CentreAnalysisResponse> ResponseCounts { get; set; }
        Task GetCandidates();
        Task GetCandidates(string sessionRef);
        Task<ServiceResponse<CandidateResponse>> GetCandidate(string regNumber);
        Task GetMultipleLoginIssues();
        Task GetMultipleLoginAnalysis();
        Task GetResponseCountAnalysis();
    }
}
