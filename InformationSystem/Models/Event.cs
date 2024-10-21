using System.ComponentModel.DataAnnotations;

namespace InformationSystem.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public DateTime EventDate { get; set; } 
        public string Description { get; set; }
        public decimal AmountOut { get; set; }
        public decimal AmountIn { get; set; }
        //FK
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
    }
}
