using JobApplication.Model;
using JobApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JobApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        [HttpGet("GetCandidatesByJob")]
        public async Task<IActionResult> GetCandidatesByJob(string job)
        {
            try
            {
                var result = await _candidateService.GetCandidatesByJob(job);
                if (result == null) return NotFound();
                return Ok(new { status = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, error = ex.Message });
            }
        }
        [HttpPost("AddCandidate")]
        public async Task<IActionResult> AddCandidate([FromForm] CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _candidateService.AddCandidate(model);
                    if (result.IsSuccess == true)
                    {
                        return Ok(new { status = true, message = result.Message });
                    }
                    return BadRequest(new { status = false, message = result.Message });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { error = ex.InnerException == null ? ex.Message : ex.InnerException.Message, status = false });
                }
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return BadRequest(new { error = messages, status = false });
            }
        }
    }
}
