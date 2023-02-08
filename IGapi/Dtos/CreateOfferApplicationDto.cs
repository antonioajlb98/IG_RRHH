using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGapi.Dtos
{
    public class CreateOfferApplicationDto
    {
        public DateTime Entry_Date { get; set; }
        public DateTime Assignment_Date { get; set; }
        //public IFormFile? Technical_Test { get; set; }
        public string? Description { get; set; }
        [DefaultValue("false")]
        public bool IsAccepted { get; set; }
        public int? Id_Candidate { get; set; }
        public int? Id_Oferta { get; set; }
    }
}
