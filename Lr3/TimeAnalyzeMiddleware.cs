public class TimeAnalyzeMiddleware
{
    private readonly RequestDelegate next;
    private readonly TimeAnalyzerService timeAnalyzerService;

    public TimeAnalyzeMiddleware(RequestDelegate next, TimeAnalyzerService timeAnalyzerService)
    {
        this.next = next;
        this.timeAnalyzerService = timeAnalyzerService;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/time")
        {
            string responseHtml = $"<h2>Time Analysis:</h2>{timeAnalyzerService.AnalyzeTime()}";

            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(responseHtml);
        }
        else
        {
            await next.Invoke(context);
        }
    }
}