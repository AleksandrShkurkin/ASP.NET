class ErrorLoggingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorLoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            LogException(ex);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Error encountered! Check error.txt for more info");
        }
    }

    private void LogException(Exception ex)
    {
        var filePath = "error.txt";

        using(var writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("=========");
            writer.WriteLine($"Date: {DateTime.Now}");
            writer.WriteLine($"Message: {ex.Message}");
            writer.WriteLine($"Stack trace: {ex.StackTrace}");
            writer.WriteLine("=========");
        }
    }
}