using System.Text.Json;

namespace AutobotBlazor.Server.Service.ExternalCandidateService
{
    public class ExternalCandidateService : IExternalCandidateService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExternalCandidateService> _logger;

        public ExternalCandidateService(HttpClient httpClient, ILogger<ExternalCandidateService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<ExternalCandidate>>> GetCandidatesByCentreId(string date, int session, string centreId)
        {
            try
            {
                var url = $"http://172.30.54.233:7070/monitor/centremonitoring/listcandidates/{date}/{session}/{centreId}";
                var result = await _httpClient
                   .GetFromJsonAsync<List<ExternalCandidate>>(url);

                //var response = await _httpClient.GetAsync(url);
                //var json = await response.Content.ReadAsStringAsync();            
                //var options = new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //};

                //List<ExternalCandidate>? result = 
                //    JsonSerializer.Deserialize<List<ExternalCandidate>>(json, options);

                if (result is null)
                {
                    return new ServiceResponse<List<ExternalCandidate>>
                    {
                        Success = false,
                        Message = "No data found"
                    };
                }

                var filteredCandidates = result
                    .Where(r => r.IpAddress is not null)
                    .ToList();

                return new ServiceResponse<List<ExternalCandidate>>
                {
                    Data = filteredCandidates
                };
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "HTTP error calling external API");
                throw;
            }
            catch (NotSupportedException nsEx)
            {
                _logger.LogError(nsEx, "The content type is not supported");
                throw;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Invalid JSON in response");
                throw;
            }
        }

        public async Task<ServiceResponse<List<ExternalCentre>>> GetCentresBySession(string date, int session)
        {
            try
            {
                var url = $"http://172.30.54.233:7070/monitor/centremonitoring/list/{date}/{session}";
                var result = await _httpClient
                   .GetFromJsonAsync<List<ExternalCentre>>(url);

                if (result is null)
                {
                    return new ServiceResponse<List<ExternalCentre>>
                    {
                        Success = false,
                        Message = "No data found"
                    };
                }

                return new ServiceResponse<List<ExternalCentre>>
                {
                    Data =  result
                };
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "HTTP error calling external API");
                throw;
            }
            catch (NotSupportedException nsEx)
            {
                _logger.LogError(nsEx, "The content type is not supported");
                throw;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Invalid JSON in response");
                throw;
            }
        }
    }
}
