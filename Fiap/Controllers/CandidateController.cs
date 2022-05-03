using Microsoft.AspNetCore.Mvc;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Enums;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models.Request;
using Fiap.Domain.Strings;

namespace Fiap.Api.Controllers
{
    [Route("api/candidate")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateDomainService _victimDomainService;

        public CandidateController(ICandidateDomainService victimDomainService)
        {
            _victimDomainService = victimDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateCreateRequest VictimCreate)
        {
            try
            {

                var hasSuccess = await _victimDomainService.CreateCandidate(VictimCreate);  

                if (!hasSuccess)
                    throw new Exception();

                return StatusCode(HttpCodes.Created);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [HttpPost("{candidateId}/skills")]
        public async Task<IActionResult> InsertCandidateSkills([FromRoute] int candidateId, [FromQuery] List<string> skills)
        {
            try
            {

                var hasSuccess = await _victimDomainService.InsertCandidateSkills(candidateId, skills);

                if (!hasSuccess)
                    throw new Exception();

                return StatusCode(HttpCodes.Created);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [HttpPost("{candidateId}/certifications")]
        public async Task<IActionResult> InsertCandidateCertifications([FromRoute] int candidateId, [FromQuery] List<string> certifications)
        {
            try
            {

                var hasSuccess = await _victimDomainService.InsertCandidateCertifications(candidateId, certifications);

                if (!hasSuccess)
                    throw new Exception();

                return StatusCode(HttpCodes.Created);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCandidates([FromQuery] string? skill, string? certification)
        {
            try
            {

                return Ok(await _victimDomainService.GetCandidates());
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }        

    }
}
