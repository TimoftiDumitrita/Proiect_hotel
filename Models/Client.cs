using System.ComponentModel.DataAnnotations;

namespace Proiect_hotel.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string Nume {  get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string Prenume {  get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email {  get; set; }
        [Display(Name ="Numar telefon")]
        public string? Nr_telefon {  get; set; }
        [Display(Name = "Nume intreg")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
    }
}
