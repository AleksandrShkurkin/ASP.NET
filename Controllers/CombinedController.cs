using Microsoft.AspNetCore.Mvc;

public class CombinedController : Controller
{
    private readonly WeatherService _weatherService;

    public CombinedController()
    {
        _weatherService = new WeatherService();
    }

    public async Task<IActionResult> Index(string city = "Kyiv")
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 100 },
            new Product { Id = 2, Name = "Product B", Price = 200 },
            new Product { Id = 3, Name = "Product C", Price = 300 }
        };

        var weather = await _weatherService.GetWeatherAsync(city);

        var model = new CombinedModel
        {
            Products = products,
            Weather = weather
        };

        return View(model);
    }
}