using System.ComponentModel.DataAnnotations;
namespace AsphaltsProducts.Presentation.Layer.Models
{
    public class ContactFormViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Domain { get; set; }
        public bool LikeToHearback { get; set; }
        [Required]
        public string Feedback { get; set; }

    }
}
