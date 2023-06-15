using AutobotBlazor.Shared.Models;
using AutobotBlazor.Shared.Services;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;

namespace AutobotBlazor.Client.Service.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private readonly HttpClient _http;

        public CandidateService(HttpClient http)
        {
            _http = http;
        }
        public string Message { get; set; } = "Loading Candidates...";
        public List<CandidateResponse> Candidates { get; set; } = new();
        public List<CentreAnalysisResponse> MultipleLogins { get; set; } = new();
        public List<CentreAnalysisResponse> ResponseCounts { get; set; } = new();

        public async Task<ServiceResponse<CandidateResponse>> GetCandidate(string regNumber)
        {
            var result = await _http
             .GetFromJsonAsync<ServiceResponse<CandidateResponse>>($"api/candidates/{regNumber}");

            if (result is not null && result.Data is not null)
            {
                var hostIPs = JsonSerializer.Deserialize<List<HostIP>>(result.Data.PreviousHostIps);
                result.Data.HostIPs = hostIPs!;
            }
            return result!;
        }

        public async Task GetCandidates()
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<List<CandidateResponse>>>("api/candidates");
            if (result is null || result.Data is null || result.Data.Count == 0)
            {
                Message = "No candidate found.";
                Candidates = new();
            }
            else
            {
                result.Data.ForEach(c => c.HostIPs = JsonSerializer.Deserialize<List<HostIP>>(c.PreviousHostIps)!);
                Candidates = result.Data;
            }
        }

        public async Task GetCandidates(string sessionRef)
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<List<CandidateResponse>>>($"api/candidates/session/{sessionRef}");
            if (result is null || result.Data is null || result.Data.Count == 0)
            {
                Message = "No candidate found.";
                Candidates = new();
            }
            else
            {
                result.Data.ForEach(c => c.HostIPs = JsonSerializer.Deserialize<List<HostIP>>(c.PreviousHostIps)!);
                Candidates = result.Data;
            }
        }

        public async Task GetMultipleLoginIssues()
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<List<CandidateResponse>>>("api/candidates/multiple-login-issues");
            if (result is null || result.Data is null || result.Data.Count == 0)
            {
                Message = "No candidate found.";
                Candidates = new();
            }
            else
            {
                result.Data.ForEach(c => c.HostIPs = JsonSerializer.Deserialize<List<HostIP>>(c.PreviousHostIps)!);
                Candidates = result.Data;
            }
        }

        public async Task GetMultipleLoginAnalysis()
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<List<CentreAnalysisResponse>>>("api/candidates/multiple-login-analysis");
            if (result is null || result.Data is null || result.Data.Count == 0)
            {
                Message = "No record found.";
                MultipleLogins = new();
            }
            else
            {               
                MultipleLogins = result.Data;
            }
        }

        public async Task GetResponseCountAnalysis()
        {
            var result = await _http
                  .GetFromJsonAsync<ServiceResponse<List<CentreAnalysisResponse>>>("api/candidates/response-count-analysis");
            if (result is null || result.Data is null || result.Data.Count == 0)
            {
                Message = "No record found.";
                ResponseCounts = new();
            }
            else
            {
                ResponseCounts = result.Data;
            }
        }
    }
}