using InformationSystem.Data;
using InformationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Service
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByDateRangeAsync(int driverId, DateTime startDate, DateTime endDate)
        {
            return await _context.Events
                .Where(e => e.DriverID == driverId && e.EventDate >= startDate && e.EventDate <= endDate)
                .OrderByDescending(e => e.EventDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsForDriverAsync(int driverId)
        {
            return await _context.Events
                .Where(e => e.DriverID == driverId)
                .OrderByDescending(e => e.EventDate)
                .ToListAsync();
        }
    }
}
