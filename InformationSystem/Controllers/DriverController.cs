using InformationSystem.Models;
using InformationSystem.Service;
using InformationSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class DriverController : Controller
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IEventRepository _eventRepository;
        public DriverController(IDriverRepository driverRepository, IEventRepository eventRepository)
        {
            _driverRepository = driverRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index(DateTime? fromdate, DateTime? toDate)
        {
            var drivers = await _driverRepository.GetAllDriversAsync();

            IEnumerable<Event> events = new List<Event>();

            if (fromdate.HasValue && toDate.HasValue)
            {
                events = await _eventRepository.GetEventsByDateRangeAsync(null,fromdate.Value, toDate.Value);
            }

            var model = new DriverEventViewModel
            {
                Drivers = drivers,
                Events = events,
                FromDate = fromdate,
                ToDate = toDate
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id, DateTime? startDate, DateTime? endDate)
        {
            if(id == null)
            {
                return NotFound();
            }
            var driver = await _driverRepository.GetDriverByIdAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }

            IEnumerable<Event> driverEvents;

            if (startDate.HasValue && endDate.HasValue)
            {
                driverEvents = await _eventRepository.GetEventsByDateRangeAsync(id.Value, startDate.Value, endDate.Value);
            }
            else
            {
                driverEvents = await _eventRepository.GetEventsForDriverAsync(id.Value);
            }

            var model = new DriverDetailsViewModel
            {
                Driver = driver,
                DriverEvents = driverEvents
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post: Driver/Create (Create new driver)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverID, DriverName, CarReg, NoteDate, NoteDescription, ResponsibleEmployee")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                await _driverRepository.AddDriverAsync(driver);
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        //GET: Driver/Edit/5 (Edit form)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driver = await _driverRepository.GetDriverByIdAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        //POST: Driver/Edit/5 (Edit driver)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverID, DriverName, CarReg, NoteDate, NoteDescription, ResponsibleEmployee")] Driver driver)
        {
            if (id != driver.DriverID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _driverRepository.UpdateDriverAsync(driver);
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: Driver/Delete/5 (Delete confirmation)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _driverRepository.GetDriverByIdAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Driver/Delete/5 (Delete driver)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _driverRepository.DeleteDriverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
        //GET: Driver/Search (Search for driver)
        public IActionResult Search()
        {
            return View();
        }

        //POST: Driver/Search (Search for driver)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string name)
        {
            var driver = await _driverRepository.SearchDriverAsync(name);
            if (driver == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details", new { id = driver.DriverID });
        }
    }
}
