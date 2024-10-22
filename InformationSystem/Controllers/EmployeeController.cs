using InformationSystem.Models;
using InformationSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task <IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(string id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Add Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PhoneNumber,Role,Password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.UserName = employee.Email;
                await _employeeRepository.AddEmployeeAsync(employee, employee.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        //Get Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id); 
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Post Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Email,PhoneNumber,Role")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //Get Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id); 
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Post Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
