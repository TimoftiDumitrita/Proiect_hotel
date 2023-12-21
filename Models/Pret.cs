namespace Proiect_hotel.Models
{

    public enum Currency { 
    Euro,
    RON
    }

    public class Pret
    {
        public int ID { get; set; }
        public DateTime StartValidity { get; set; }
        public DateTime EndValidity { get; set;}
        public decimal Price_value { get; set; }
        public Currency Currency { get; set;}
        public int Nr_persoane {  get; set; }
        public int? CameraID { get; set; }
        public Camera? Camere { get; set; }


    }
}
