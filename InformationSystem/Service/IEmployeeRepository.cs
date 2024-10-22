using InformationSystem.Models;

namespace InformationSystem.Service
{
    public interface IEmployeeRepository
    {
        //Crud operations for Employee class
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task AddEmployeeAsync(Employee employee, string password);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string id);
    }
}
