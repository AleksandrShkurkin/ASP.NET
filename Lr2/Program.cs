using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("companies.json")
.AddIniFile("companies.ini")
.AddXmlFile("companies.xml");

var app = builder.Build();

var jsonCompanies = GetCompaniesSections(app.Configuration.GetSection("companies"));
var xmlCompanies = GetCompaniesSections(app.Configuration.GetSection("companies:company"));
var iniCompanies = GetCompaniesIni(app.Configuration);

app.Run(async (context) =>
{
    var json = AnalyzeCompanies(jsonCompanies, "JSON");
    var xml = AnalyzeCompanies(xmlCompanies, "XML");
    var ini = AnalyzeCompanies(iniCompanies, "INI");
    await context.Response.WriteAsync($"{json}\n{xml}\n{ini}");
});

app.Run();

List<Company> GetCompaniesSections(IConfigurationSection section)
{
    var companies = new List<Company>();
    foreach (var item in section.GetChildren())
    {
        var name = item["name"];
        var yearOfCreation = item["yearOfCreation"];
        var value = item["value"];
        var amountOfWorkers = item["amountOfWorkers"];
        if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(yearOfCreation) && !string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(amountOfWorkers))
        {
            companies.Add(new Company(name, int.Parse(yearOfCreation), value, int.Parse(amountOfWorkers)));
        }
    }
    return companies;
}

List<Company> GetCompaniesIni(IConfiguration configuration)
{
    var companies = new List<Company>();
    var sections = new[] { "Microsoft", "Apple", "Google" };

        foreach (var section in sections)
        {
            var yearOfCreation = int.Parse(configuration[$"{section}:yearOfCreation"]);
            var value = configuration[$"{section}:value"];
            var amountOfWorkers = int.Parse(configuration[$"{section}:amountOfWorkers"]);
            companies.Add(new Company(section, yearOfCreation, value, amountOfWorkers));
        }
        return companies;
}

string AnalyzeCompanies(List<Company> companies, string fileType)
    {
        var maxCompany = companies.OrderByDescending(c => c.AmountOfWorkers).FirstOrDefault();
        if (maxCompany != null)
        {
            return $"In {fileType} company with the most amount of workers: {maxCompany.Name} ({maxCompany.AmountOfWorkers})";
        }
        return "";
    }