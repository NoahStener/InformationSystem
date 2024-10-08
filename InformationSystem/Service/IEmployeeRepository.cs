using InformationSystem.Models;

namespace InformationSystem.Service
{
    public interface IEmployeeRepository
    {
        //Crud operations for Employee class
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
