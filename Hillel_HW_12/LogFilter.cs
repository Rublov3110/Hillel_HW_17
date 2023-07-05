using Microsoft.AspNetCore.Mvc.Filters;

namespace Hillel_HW_12
{
    public class LogFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string failePathe = "D:/C#/Hillel/Hillel_HW_17/Log.txt";
            string content = "Write: " + DateTime.Now + ": " + context.HttpContext.Request.Path;
            Console.WriteLine($"Writ {DateTime.Now} {context.HttpContext.Request.Path}");
            using (StreamWriter sw = new StreamWriter(failePathe, true))
            {
                sw.WriteLine(content);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

            Console.WriteLine($"v2 After {context.HttpContext.Request.Path}");
        }
    }
}
