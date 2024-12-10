using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.Enrich.FromLogContext()
.Enrich.WithExceptionDetails()
.WriteTo.Console()
.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
.WriteTo.Email(
    from: "saha.sanek.555@gmail.com",
    to: "kirilshwed@gmail.com",
    host: "smtp.gmail.com",
    port: 587,
    credentials: new System.Net.NetworkCredential("saha.sanek.555@gmail.com", "wmpw cgqk dusm ozuv")
)
.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
