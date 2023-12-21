using System.ComponentModel.DataAnnotations;

namespace Proiect_hotel.Models
{
    public class Camera
    {
        public int ID { get; set; }
        [Display(Name = "Numar camera")]
        public int NumarCamera { get; set; }
        public string? Detalii { get; set; }

    
    }
}
