using InformationSystem.Models;

namespace InformationSystem.ViewModels
{
    public class DriverDetailsViewModel
    {
        public Driver Driver { get; set; }
        public IEnumerable<Event> DriverEvents { get; set; }
    }
}
