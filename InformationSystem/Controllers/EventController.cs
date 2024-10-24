using InformationSystem.Data;
using InformationSystem.Models;
using InformationSystem.Service;
using InformationSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepo;
        private readonly IDriverRepository _driverRepo;
        public EventController(IEventRepository eventRepo, IDriverRepository driverRepo)
        {
            _eventRepo = eventRepo;
            _driverRepo = driverRepo;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEvent(int driverId)
        {
            var model = new Event { DriverID = driverId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                var newEvent = new Event
                {
                    DriverID = model.DriverID,
                    Description = model.Description,
                    EventDate = model.EventDate,
                    AmountIn = model.AmountIn,
                    AmountOut = model.AmountOut
                };
                await _eventRepo.AddEventAsync(newEvent);

                var driver = await _driverRepo.GetDriverByIdAsync(model.DriverID);
                if (driver != null)
                {
                    driver.TotalAmountOut += model.AmountOut;
                    driver.TotalAmountIn += model.AmountIn;
                    await _driverRepo.UpdateDriverAsync(driver);
                }

                return RedirectToAction("Details", "Driver", new { id = model.DriverID });
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.WriteLine($"Description: {model.Description}, EventDate: {model.EventDate}, DriverID: {model.DriverID}");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Notifications()
        {
            var recentEvents = await _eventRepo.GetEventsWithinTimeSpanAsync(User.IsInRole("Admin") ? TimeSpan.FromHours(24) : TimeSpan.FromHours(12));

            var model = new NotificationsViewModel
            {
                RecentEvents = recentEvents
            };
            return View(model);
        }


    
       
    }
}
