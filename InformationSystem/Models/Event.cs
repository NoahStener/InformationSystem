namespace InformationSystem.Models
{
    public class Event
    {
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public decimal AmountIn { get; set; }
        public decimal AmountOut { get; set; }
    }
}
