using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromQuery]DateTime date, string city)
        {
            if (city == "Houston")
            {
                if (date < new DateTime(2024, 1, 1))
                {
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(date),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        })
                        .ToArray();
                }
                else
                {
                    return new List<WeatherForecast>()
                    {
                        new WeatherForecast()
                        {
                            Date = DateOnly.FromDateTime(date),
                            TemperatureC = 15,
                            Summary = "Nice and sunny"
                        }
                    };
                }

            }
            else if (city == "Chicago")
            {
                throw new NotImplementedException();
            }
            else
            {
                return new List<WeatherForecast>();
            }
        }
    }
}
