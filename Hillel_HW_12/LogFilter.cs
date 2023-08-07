using Microsoft.AspNetCore.Mvc.Filters;

namespace Hillel_HW_12
{
    public class LogFilter : Attribute, IActionFilter
    {
        public LogFilter(ILogger<LogFilter> logger)
        {
            Logger = logger;
        }
        public ILogger<LogFilter> Logger { get; }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogTrace($"v2 After {context.HttpContext.Request.Path}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

            Logger.LogTrace($"v2 Before {context.HttpContext.Request.Path}");
        }
    }
}
