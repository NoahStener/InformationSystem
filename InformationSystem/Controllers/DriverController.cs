using InformationSystem.Models;
using InformationSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverRepository _driverRepository;
        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverRepository.GetAllDriversAsync();
            return View(drivers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var driver = await _driverRepository.GetDriverByIdAsync(id);
            return View(driver);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post: Driver/Create (Create new driver)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverID, DriverName, CarReg, NoteDate, NoteDescription, ResponsibleEmployee, AmountOut, AmountIn")] Driver driver)
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
        public async Task<IActionResult> Edit(int id, [Bind("DriverID, DriverName, CarReg, NoteDate, NoteDescription, ResponsibleEmployee, AmountOut, AmountIn")] Driver driver)
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


    }
}
