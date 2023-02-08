using IGapi.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IGapi.Models
{
    [Table("Candidates")]
    public class CandidateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public CandidateDto ParseToDto()
        {
            return new CandidateDto 
            {   
                Id = Id,
                Name = Name,
                Dni = Dni,
                Gender = Gender,
                Birthdate = Birthdate,
                Mail = Mail,
                Password = Password
                
            };
        }
    }
}
