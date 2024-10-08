using InformationSystem.Models;

namespace InformationSystem.Service
{
    public interface IDriverRepository
    {
        //Crud operations for Driver class
        //Can we make all these operations async?

        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int id);
        Task AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task DeleteDriverAsync(int id);

    }
}
