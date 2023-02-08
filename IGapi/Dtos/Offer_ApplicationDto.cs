using System.ComponentModel;

namespace IGapi.Dtos
{
    public class Offer_ApplicationDto
    {
        public int Id { get; set; }
        public DateTime Entry_Date { get; set; }
        public DateTime Assignment_Date { get; set; }
        //public IFormFile? Technical_Test { get; set; }
        public string? Description { get; set; }
        [DefaultValue("false")]
        public bool IsAccepted { get; set; }
        public virtual CandidateDto? Candidate { get; set; }
        public virtual OfferDto? Offer { get; set; }

        public CreateOfferApplicationDto ParseToCreateDto()
        {
            return new CreateOfferApplicationDto
            {
                Entry_Date= Entry_Date,
                Assignment_Date= Assignment_Date,
                //Technical_Test= Technical_Test,
                Description= Description,
                IsAccepted= IsAccepted,
                Id_Candidate = Candidate.Id,
                Id_Oferta = Offer.Id
            };
        }

    }

    
}
