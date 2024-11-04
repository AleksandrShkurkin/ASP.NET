var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FormService>();

var app = builder.Build();
var formService = app.Services.GetRequiredService<FormService>();

app.UseMiddleware<ErrorLoggingMiddleware>();
app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapPost("/submit", async (HttpContext context) => {
    var check = formService.HandleSubmission(context);
    if(check == true)
    {
        await context.Response.WriteAsync("Cookie saved!");
    }
    else
    {
        await context.Response.WriteAsync("Wrong date and/or time!");
    }
});

app.MapGet("/check", async (HttpContext context) => {
    var cookieValue = formService.OutputCookie(context);
    if(cookieValue == null)
    {
        await context.Response.WriteAsync("Cookie not set");
    }
    else
    {
        await context.Response.WriteAsync(cookieValue);
    }
});

app.MapGet("/error/{a}-{b}", async(HttpContext context, int a, int b) => {
    await context.Response.WriteAsync($"{a/b}");
});

app.Run();
