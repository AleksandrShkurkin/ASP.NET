var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("books.json").AddJsonFile("profiles.json");

var app = builder.Build();

app.Map("/Library", () => "Welcome to the Library page!");
app.Map("/Library/Books", () => Books.BooksOut(app.Configuration.GetSection("books")));
app.Map("/Library/Profile/{id:int:range(0, 5)?}", (int? id) => Profile.GetProfile(id, app.Configuration.GetSection("profiles")));

app.Run();
