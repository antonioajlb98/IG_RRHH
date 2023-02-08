using IGapi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGapi.Dtos
{
    public class CandidateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        public List<CreateOfferApplicationDto>? Applications { get; set; }

        public CandidateModel ParseToModel()
        {
            return new CandidateModel
            {
                Id = Id,
                Name = Name,
                Dni = Dni,
                Gender = Gender,
                Birthdate = Birthdate,
                Mail = Mail,
                Password = Password,
            };
        }
    }
}
