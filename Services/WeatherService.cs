using Newtonsoft.Json;

public class WeatherService
{
    private readonly string _apiKey = "56a98fb17411980ef1f4475631e8fc9b";
    private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public async Task<Weather> GetWeatherAsync(string city)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync($"{_baseUrl}?q={city}&appid={_apiKey}&units=metric");
            var weatherData = JsonConvert.DeserializeObject<dynamic>(response);

            return new Weather
            {
                City = weatherData.name,
                Temperature = weatherData.main.temp,
                FeelTemperature = weatherData.main.feels_like,
                WindSpeed = weatherData.wind.speed,
                WeatherDescription = weatherData.weather[0].description
            };
        }
    }
}