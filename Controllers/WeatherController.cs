using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherApi : ControllerBase
    {
        private readonly ILogger<WeatherApi> _logger;
        static readonly Models.IWeatherRepository repository = new Models.WeatherRepository();
        public WeatherApi(ILogger<WeatherApi> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("weather")]
        public Models.Weather GetWeather(string city)
        {
            return repository.GetWeather(city);
        }
    }
    
}