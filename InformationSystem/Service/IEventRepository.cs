using InformationSystem.Models;

namespace InformationSystem.Service
{
    public interface IEventRepository
    {
        
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<IEnumerable<Event>> GetEventsForDriverAsync(int driverId);
        Task AddEventAsync(Event newEvent);
        Task<IEnumerable<Event>> GetEventsByDateRangeAsync(int? driverId, DateTime startDate, DateTime endDate);
    }
}
