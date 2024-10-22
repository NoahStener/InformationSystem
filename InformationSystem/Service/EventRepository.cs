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

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await
            _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByDateRangeAsync(int? driverId, DateTime startDate, DateTime endDate)
        {
            var query = _context.Events.AsQueryable();

            if(driverId.HasValue && driverId > 0)
            {
                query = query.Where(e => e.DriverID == driverId.Value);
            }

            query = query.Where(e => e.EventDate >= startDate && e.EventDate <= endDate);
            return await query.OrderByDescending(e => e.EventDate).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsForDriverAsync(int driverId)
        {
            return await _context.Events
                .Where(e => e.DriverID == driverId)
                .OrderByDescending(e => e.EventDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetRecentEventsAsync()
        {
            var twelveHoursAgo = DateTime.Now.AddHours(-12);
            return await _context.Events
                .Include(e => e.Driver)
                .Where(e => e.EventDate >= twelveHoursAgo)
                .OrderByDescending(e => e.EventDate)
                .ToListAsync();
        }
    }
}
