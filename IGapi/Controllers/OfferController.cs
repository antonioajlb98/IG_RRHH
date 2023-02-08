using IGapi.Dtos;
using IGapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace IGapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController
    {
        private readonly OfferService offerService;

        public OfferController (OfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet("GetAll")]
        public List<OfferDto> GetAll()
        {
            return offerService.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public OfferDto Get(int id)
        {
            return offerService.GetById(id);
        }

        [HttpPost("Insert")]
        public bool Insert([FromBody]OfferDto offer)
        {
            return offerService.Insert(offer);
        }

        [HttpDelete("Delete/{id}")]
        public bool Delete(int id)
        {
            return offerService.Delete(id);
        }
    }
}
