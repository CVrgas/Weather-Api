namespace WeatherApi.Models
{
    public class Weather
    {
        public string? Location { get; set; }
        public DateTime localtime { get; set; }
        public int TemperatureC { get; set; }
        public int Humidity { get; set; }
        public string? SkyView { get; set; }
        public List<Overtime>? per_hour {get; set;}
        public List<Overtime>? per_week {get; set;}
    }

    public class Overtime
    {
        public DateTime date { get; set; }
        public int TemperatureC { get; set; }
        public int Humidity { get; set; }
        public string?  SkyView { get; set; }

    }
}