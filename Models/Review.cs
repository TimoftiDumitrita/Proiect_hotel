using System.ComponentModel.DataAnnotations;

namespace Proiect_hotel.Models
{

    public enum Rate {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5

    }

    public class Review
    {
        public int Id { get; set; }
       
        public string Mesaj {  get; set; }
        public Rate Rate {  get; set; }
        public int ClientID { get; set; }
        public Client? Client { get; set; }
    }
}
