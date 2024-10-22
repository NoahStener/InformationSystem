using InformationSystem.Data;
using InformationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public EmployeeRepository(AppDbContext context, UserManager<Employee> userManger, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManger;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee, string password)
        {
            var result = await _userManager.CreateAsync(employee, employee.Password);
            if (result.Succeeded && !string.IsNullOrEmpty(employee.Role))
            {
                await _userManager.AddToRoleAsync(employee, employee.Role);
            }
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee != null)
            {
                await _userManager.DeleteAsync(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _userManager.FindByIdAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.UserName = employee.Email;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.Role = employee.Role;

                var result = await _userManager.UpdateAsync(existingEmployee);
                if (result.Succeeded && !string.IsNullOrEmpty(employee.Role))
                {
                    var currentRoles = await _userManager.GetRolesAsync(existingEmployee);
                    await _userManager.RemoveFromRolesAsync(existingEmployee, currentRoles);
                    await _userManager.AddToRoleAsync(existingEmployee, employee.Role);
                }
            }
        }
    }
}
