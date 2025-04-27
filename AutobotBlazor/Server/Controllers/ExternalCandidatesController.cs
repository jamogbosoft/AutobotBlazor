using AutobotBlazor.Server.Service.ExternalCandidateService;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace AutobotBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalCandidatesController : ControllerBase
    {
        private readonly IExternalCandidateService _externalCandidateService;
        private readonly ICandidateService _candidateService;
        private DataContext _context;
        public ExternalCandidatesController(IExternalCandidateService externalCandidateService, ICandidateService candidateService, DataContext context)
        {
            _externalCandidateService = externalCandidateService;
            _candidateService = candidateService;
            _context = context;
        }

        [HttpGet("{date}/{session}/{centreId}")]
        public async Task<ActionResult<ServiceResponse<List<ExternalCandidate>>>> GetCandidatesByCentreId(string date, int session, string centreId)
        {
            var result = await _externalCandidateService.GetCandidatesByCentreId(date, session, centreId);
            if (result is null)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

        [HttpGet("centres/{date}/{session}")]
        public async Task<ActionResult<ServiceResponse<List<ExternalCentre>>>> GetCentresBySession(string date, int session)
        {
            var result = await _externalCandidateService.GetCentresBySession(date, session);
            if (result is null)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

        [HttpGet("pull-data/{date}/{session}/{centreId}")]
        public async Task PullExternalCandidatesByCentreId(string date, int session, string centreId)
        {
            var result = await _externalCandidateService.GetCandidatesByCentreId(date, session, centreId);
            if (result is null || result.Data is null)
                return;
            var candidates = result.Data;
            await AddCandidates(candidates);
            await  _context.SaveChangesAsync();
        }

       
        [HttpGet("pull-data-with-Range/{date}/{session}/{startFrom}")]
        public async Task PullExternalCandidatesBySession(string date, int session, long startFrom)
        {
            var centreResult = await _externalCandidateService.GetCentresBySession(date, session);
            if (centreResult is null || centreResult.Data is null)
                return;

            var centres = centreResult.Data;
            await AddCandidatesByCentre(date, session, centres, startFrom);
            await _context.SaveChangesAsync();
        }

        private async Task AddCandidatesByCentre(string date, int session, List<ExternalCentre> centres, long startFrom)
        {
            int n = 100;
            var xCentres = centres
                .Where(c => c.CID >= startFrom)
                .Take(n)                
                .ToList();
            foreach (var centre in xCentres)
            {
                var candidateResult = await _externalCandidateService
                    .GetCandidatesByCentreId(date, session, centre.CentreID);
                if (candidateResult is null || candidateResult.Data is null)
                    break;
                var candidates = candidateResult.Data;
                await AddCandidates(candidates);
            }
        }

        private async Task AddCandidates(List<ExternalCandidate> candidates)
        {
            foreach (var candidate in candidates)
            {
                await AddCandidate(candidate);
            }
        }

        private async Task AddCandidate(ExternalCandidate candidate)
        {
            CandidateResponse candidateResponse = new CandidateResponse()
            {
                CentreId = candidate.CentreID.Substring(0, 3),
                SessionRef = candidate.CentreID,
                ExamDate = candidate.Date,
                Timestamp = candidate.Timestamp,
                Name = candidate.Name,
                RegistrationNumber = candidate.RegistrationNumber,
                Status = candidate.Status,
                TotalAttempted = candidate.ResponsesCount,
                StartTime = candidate.StartTime ?? string.Empty,
                EndTime = candidate.EndTime ?? string.Empty,
                Duration = candidate.Duration,
                IpAddress = candidate.IpAddress ?? string.Empty,
                PreviousHostIps = candidate.PreviousHostIps,
                Bvm = candidate.Bvm,
                BvmStatus = candidate.BvmStatus,
                TimedOut = candidate.TimedOut,
                Connected = candidate.Connected
            };

            await _candidateService.AddCandidateResponse(candidateResponse);
        }

    }
}
