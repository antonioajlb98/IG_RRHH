using IGapi.Context;
using IGapi.Dtos;
using IGapi.Models;
using IGapi.Repositories;

namespace IGapi.Services
{
    public class Offer_ApplicationService
    {
        private readonly Offer_ApplicationRepository offer_applicationRepo;
        private readonly ApplicationDBContext db;

        public Offer_ApplicationService(Offer_ApplicationRepository offer_applicationRepo, ApplicationDBContext database)
        {
            this.offer_applicationRepo = offer_applicationRepo;
            this.db = database;
        }

        public bool Insert(CreateOfferApplicationDto offer_Application)
        {
            if(offer_Application != null)
            {
                var aux = new Offer_ApplicationModel()
                {
                    
                    Assignment_Date =   offer_Application.Assignment_Date,
                    Description =       offer_Application.Description,
                    Entry_Date =        offer_Application.Entry_Date,
                    IsAccepted =        offer_Application.IsAccepted,
                    Candidate =         db.Candidates.FirstOrDefault(c => c.Id == offer_Application.Id_Candidate),
                    Offer =             db.Offers.FirstOrDefault(o => o.Id == offer_Application.Id_Oferta)
                };
                //if(offer_Application.Technical_Test != null ) 
                //{
                //    var ms = new MemoryStream();
                //    offer_Application.Technical_Test.CopyTo(ms);
                //    var fileBytes = ms.ToArray();
                //    aux.Technical_Test = fileBytes;
                //}
                return offer_applicationRepo.Insert(aux);
            }
            return false;
            
        }

        public Offer_ApplicationDto Get(int id)
        {
            return offer_applicationRepo.Get(id).ParseToDto();  
        }

        public List<Offer_ApplicationDto> GetAll()
        {
            List<Offer_ApplicationDto> offers = new List<Offer_ApplicationDto>();
            offers = offer_applicationRepo.GetAll().Select(C => C.ParseToDto()).ToList();
            return offers;
        }
    }
}
