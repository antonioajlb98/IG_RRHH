using IGapi.Dtos;
using IGapi.Models;
using IGapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IGapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {

        private readonly CandidateService candidateServ;

        public CandidateController(CandidateService candidateServ)
        {
            this.candidateServ = candidateServ;
        }

        [HttpGet("GetAll")]
        public List<CandidateDto> GetAll() 
        {
            return candidateServ.GetCandidates();
        }

        [HttpGet("GetById/{id}")]
        public CandidateDto GetCandidate(int id)
        {
            return candidateServ.GetCandidate(id);
        }

        [HttpPost("Insert")]
        public bool Insert([FromForm] CandidateDto candidate)
        {
            return candidateServ.Insert(candidate);
        }

        [HttpDelete("Delete/{id}")]
        public bool Delete(int id)
        {
            return candidateServ.Delete(id);
        }


    }
}
