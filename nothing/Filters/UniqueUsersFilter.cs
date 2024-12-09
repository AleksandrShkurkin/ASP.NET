using Microsoft.AspNetCore.Mvc.Filters;

public class UniqueUsersFilter : IActionFilter
{
    private static HashSet<string> _uniqueUsers = new HashSet<string>();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userIP = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (!string.IsNullOrEmpty(userIP))
        {
            if (!_uniqueUsers.Contains(userIP))
            {
                _uniqueUsers.Add(userIP);

                File.AppendAllText("user_log.txt", $"New user IP detected: {userIP}\nAmount of unique users as of now: {_uniqueUsers.Count}\n");
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}