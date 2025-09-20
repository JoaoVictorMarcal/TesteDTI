using System.ComponentModel.DataAnnotations;

namespace testeDTI.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "É obrigatorio colocar Nome")]
        public string ContactFirstName { get; set; }
        public string? ContactFullName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string? Status { get; set; }



    }
}