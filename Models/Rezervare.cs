using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_hotel.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
        public DateTime Data_start { get; set; }
        public DateTime Data_end { get; set;}
        public decimal Pret_total {  get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client? Client {  get; set; }

    }
    
}
