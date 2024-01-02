using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_hotel.Models
{
    public class Rezervare_camera
    {
        [ForeignKey("Camera")]
        public int? CameraID { get; set; }
        public Camera? Camere { get; set; }
        [ForeignKey("Rezervare")]
        [Display(Name ="Rezervare")]
        public int? RezervareID {get; set; }
        public Rezervare? Rezervare {  get; set; }
        [Display(Name ="Numar persoane")]
        public int Nr_persoane {  get; set; }
            

        }
    }
