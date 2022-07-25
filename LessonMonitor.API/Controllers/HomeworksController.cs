using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworksController : ControllerBase
    {
        [HttpGet]
        public string Get(string title, string description, bool taskExecutionStatus)
        {
            return $"Заголовок: {title}\nОписание: {description}\nСтатус выполнения: {taskExecutionStatus}";
        }
    }
}
