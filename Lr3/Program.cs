var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CalcService>();
builder.Services.AddSingleton<CalcController>();
builder.Services.AddTransient<TimeAnalyzerService>();

var app = builder.Build();

app.UseMiddleware<TimeAnalyzeMiddleware>();
app.Run(async context =>
{
    var controller = context.RequestServices.GetRequiredService<CalcController>();
    var results = controller.ExecuteOperations(20, 4);

    string responseHtml = "<html><body><h2>Calculation Results:</h2>";
    responseHtml += string.Join("<br>", results);
    responseHtml += "</body></html>";

    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(responseHtml);
});

app.Run();
