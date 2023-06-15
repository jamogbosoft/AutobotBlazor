namespace AutobotBlazor.Server.Service.CandidateService
{
    public interface ICandidateService
    {
        Task<ServiceResponse<List<CandidateResponse>>> GetCandidateResponses();        
        Task<ServiceResponse<List<CandidateResponse>>> GetCandidateResponses(string sessionRef);
        Task<ServiceResponse<CandidateResponse>> GetCandidateResponse(string regNumber);
        Task<ServiceResponse<List<CandidateResponse>>> GetMultipleLoginIssues();
        Task<ServiceResponse<List<CentreAnalysisResponse>>> GetMultipleLoginAnalysis();
        Task<ServiceResponse<List<CentreAnalysisResponse>>> GetResponseCountAnalysis();
    }
}
