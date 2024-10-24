using InformationSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Component
{
    public class AdminEventCountViewComponent : ViewComponent
    {
        private readonly IEventRepository _eventRepo;
        public AdminEventCountViewComponent(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentEvents = await _eventRepo.GetEventsWithinTimeSpanAsync(TimeSpan.FromHours(24));
            var count = recentEvents.Count();
            return Content(count.ToString());
        }
    }
}
