using IGapi.Dtos;
using IGapi.Models;
using IGapi.Repositories;

namespace IGapi.Services
{
    public class CandidateService
    {
        private readonly CandidateRepository candidateRepo;
        private readonly Offer_ApplicationService offerApplicationService;

        public CandidateService(CandidateRepository candidateRepo, Offer_ApplicationService offer_ApplicationService)
        {
            this.candidateRepo = candidateRepo;
            this.offerApplicationService = offer_ApplicationService;
        }

        public List<CandidateDto> GetCandidates()
        {
            List<CandidateDto> candidates = new List<CandidateDto>();
            candidates = candidateRepo.GetCandidates().Select(C => C.ParseToDto()).ToList();
            return candidates;
        }

        public bool Insert(CandidateDto candidate)
        {
            if(candidate.Applications != null) 
            {
                candidate.Applications.Select(a => a.Id_Candidate = candidate.Id).ToList();
                foreach (CreateOfferApplicationDto element in candidate.Applications)
                {
                    offerApplicationService.Insert(element);
                }
            }
            return candidateRepo.Insert(candidate.ParseToModel());
        }

        public bool Delete(int id)
        {
            return candidateRepo.Delete(id);
        }

        public CandidateDto GetCandidate(int id)
        {
            var listaAplicaciones = new List<CreateOfferApplicationDto>();
            foreach(Offer_ApplicationDto offer in offerApplicationService.GetAll())
            {
                if(offer.Candidate.Id == id)
                {
                    listaAplicaciones.Add(offer.ParseToCreateDto());
                }
            }
            candidateRepo.GetbyId(id).ParseToDto().Applications = listaAplicaciones;
            return candidateRepo.GetbyId(id).ParseToDto();
        }


    }
}
