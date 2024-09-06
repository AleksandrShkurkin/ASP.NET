var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(context) => {
    var company = new Company { 
        Name = "GreenTech Innovations",
        Description = "A company engaged in the development and implementation of innovative solutions for green energy. GreenTech specializes in the creation of solar panels, wind turbines, and energy-saving technologies.",
        EmployeesAmount = 250,
        Salary = 55_000
    };

    await context.Response.WriteAsync(company.Print());

    //var numRand = new Random().Next(0, 101);
    //await context.Response.WriteAsync(numRand.ToString());
});

app.Run();
