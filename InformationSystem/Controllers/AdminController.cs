using InformationSystem.Data;
using InformationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(AdminHistoryViewModel model)
        {
            var query = _context.Events.Include(e => e.Driver).AsQueryable();

            if (model.StartDate.HasValue)
            {
                query = query.Where(e => e.EventDate >= model.StartDate);
            }

            if(model.EndDate.HasValue)
            {
                query = query.Where(e => e.EventDate <= model.EndDate);
            }

            if (!string.IsNullOrEmpty(model.DriverName))
            {
                query = query.Where(e => e.Driver.DriverName.Contains(model.DriverName));
            }

            if(!string.IsNullOrEmpty(model.EmployeeName))
            {
                query = query.Where(e => e.Driver.ResponsibleEmployee.Contains(model.EmployeeName));
            }

            model.Events = query.ToList();
            return View(model);
        }
    }
}
