var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("config.json");

var app = builder.Build();

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]}, {appConfig["surname"]}, {appConfig["age"]}");

app.Run();