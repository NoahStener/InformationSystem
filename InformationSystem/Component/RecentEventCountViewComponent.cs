using InformationSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystem.Component
{
    public class RecentEventCountViewComponent : ViewComponent
    {
        private readonly IEventRepository _eventRepository;

        public RecentEventCountViewComponent(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var recentEvents = await _eventRepository.GetRecentEventsAsync();
            var count = recentEvents.Count();
            return Content(count.ToString());
        }

    }
}
