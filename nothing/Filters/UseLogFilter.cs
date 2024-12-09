using Microsoft.AspNetCore.Mvc.Filters;

public class UseLogFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string methodName = filterContext.ActionDescriptor.DisplayName;
        string logMessage = $"Method: {methodName}, Accessed at: {DateTime.Now}\n";

        File.AppendAllText("history_log.txt", logMessage);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}