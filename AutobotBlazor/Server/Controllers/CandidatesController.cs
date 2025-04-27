using Microsoft.AspNetCore.Mvc;

namespace AutobotBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]   
        public async Task<ActionResult< ServiceResponse<List<CandidateResponse>>>> GetCandidateResponses()
        {
            var result = await _candidateService.GetCandidateResponses();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("session/{sessionRef}")]
        public async Task<ActionResult<ServiceResponse<List<CandidateResponse>>>> GetCandidateResponses(string sessionRef)
        {
            var result = await _candidateService.GetCandidateResponses(sessionRef);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("{regNumber}")]
        public async Task<ActionResult<ServiceResponse<CandidateResponse>>> GetCandidateResponse(string regNumber)
        {
            var result = await _candidateService.GetCandidateResponse(regNumber);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("multiple-login-issues")]
        public async Task<ActionResult<ServiceResponse<List<CentreAnalysisResponse>>>> GetMultipleLoginIssues()
        {
            var result = await _candidateService.GetMultipleLoginIssues();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("multiple-login-analysis")]
        public async Task<ActionResult<ServiceResponse<List<CentreAnalysisResponse>>>> GetMultipleLoginAnalysis()
        {
            var result = await _candidateService.GetMultipleLoginAnalysis();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("response-count-analysis")]
        public async Task<ActionResult<ServiceResponse<List<CentreAnalysisResponse>>>> GetResponseCountAnalysis()
        {
            var result = await _candidateService.GetResponseCountAnalysis();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        //[HttpGet("host-ip")]
        //public async Task<ActionResult<ServiceResponse<List<CandidateResponse>>>> UpdateCandidatePreviousHostIps()
        //{
        //    var result = await _candidateService.UpdateCandidatePreviousHostIps();
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound(result);
        //}
    }
}
