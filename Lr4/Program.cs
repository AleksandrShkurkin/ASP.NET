var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BooksService>();
builder.Services.AddTransient<ProfileService>();
builder.Configuration.AddJsonFile("books.json").AddJsonFile("profiles.json");

var app = builder.Build();

app.Map("/Library", () => "Welcome to the Library page!");
app.Map("/Library/Books", () => app.Services.GetService<BooksService>().BooksOut(app.Configuration.GetSection("books")));
app.Map("/Library/Profile/{id:int:range(0, 5)?}", (int? id) => app.Services.GetService<ProfileService>().GetProfile(id, app.Configuration.GetSection("profiles")));

app.Run();
