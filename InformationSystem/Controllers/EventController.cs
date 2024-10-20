using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
