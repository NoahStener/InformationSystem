using InformationSystem.Data;
using InformationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Service
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;
        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDriverAsync(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(int id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public async Task<Driver> SearchDriverAsync(string name)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.DriverName.Contains(name));
            return driver;
        }

        public Task UpdateDriverAsync(Driver driver)
        {
            _context.Drivers.Update(driver);
            return _context.SaveChangesAsync();
        }
    }
}
