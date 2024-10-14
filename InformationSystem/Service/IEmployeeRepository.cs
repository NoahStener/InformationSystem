﻿using InformationSystem.Models;

namespace InformationSystem.Service
{
    public interface IEmployeeRepository
    {
        //Crud operations for Employee class
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}