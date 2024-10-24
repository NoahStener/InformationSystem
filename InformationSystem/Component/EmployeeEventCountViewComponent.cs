using InformationSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Component
{
    public class EmployeeEventCountViewComponent : ViewComponent
    {
        private readonly IEventRepository _eventRepository;

        public EmployeeEventCountViewComponent(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentEvents = await _eventRepository.GetEventsWithinTimeSpanAsync(TimeSpan.FromHours(12));
            var count = recentEvents.Count();
            return Content(count.ToString());
        }

    }
}
