using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Proiect_hotel.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]

        public string? Nume {  get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume {  get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email {  get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
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
        public IdentityUser IdentityUser { get; set; }
    }
}
