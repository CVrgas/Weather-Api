namespace WeatherApi.Models
{
    public interface IWeatherRepository
    {
        Weather GetWeather (string city);
        
    }
}