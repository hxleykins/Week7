using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;

namespace ClassSchedule.Components
{
    public class DayFilter : ViewComponent
    {
        private IRepository<Day> days { get; set; }

        public DayFilter(IRepository<Day> dayRepo)
        {
            days = dayRepo;
        }

        public IViewComponentResult Invoke()
        {
            var options = new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            };

            var dayList = days.List(options);

            return View(dayList);
        }
    }
}