using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        [HttpGet]
        public string  Get(string title, string description)
        {
            return $"Заголовок: {title}\nОписание: {description}";
        }
    }
}
