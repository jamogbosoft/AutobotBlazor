namespace AutobotBlazor.Server.Service.ExternalCandidateService
{
    public interface IExternalCandidateService
    {
        Task<ServiceResponse<List<ExternalCandidate>>> GetCandidatesByCentreId(string date, int session, string centreId);
        Task<ServiceResponse<List<ExternalCentre>>> GetCentresBySession(string date, int session);


    }
}
