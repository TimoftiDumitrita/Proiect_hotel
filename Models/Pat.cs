using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_hotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_hotel.Models
{

    public enum Tip
    {
        Single,
        Double,
        King
    }

    public class Pat

    {
        [Display(Name = "Numar pat")]
        public int ID { get; set; }

        public double Lungime { get; set; }

        public double Latime { get; set; }
        [BindProperty]
        public Tip TipPat { get; set; }
        public int? CameraID { get; set; }

        public Camera? Camere { get; set; }
        




    } 

}