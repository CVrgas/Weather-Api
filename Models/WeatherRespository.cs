namespace WeatherApi.Models
{
    public class WeatherRepository : IWeatherRepository
    {
        public Weather GetWeather(string city)
        {
            Weather targetLocation = new Weather 
            {
                Location = city,
                localtime = DateTime.Now,
                TemperatureC = throw_dice(-10, 40), 
                Humidity = throw_dice(50, 100)
            };
            targetLocation.SkyView = sky_aparence(targetLocation.TemperatureC);
            Create_weather_overtime(targetLocation);

            return targetLocation;
        }
        public void Create_weather_overtime(Weather actual_weather){
            
            List<Overtime> hourly_weather = new List<Overtime>();
            List<Overtime> week_weather = new List<Overtime>();

            for (int i = 1; i < 8; i++)
            {
                Overtime hourly = ovetimes(actual_weather, i);
                Overtime daily = ovetimes(actual_weather, i * 24);
                hourly_weather.Add(hourly);
                week_weather.Add(daily);
            }
            actual_weather.per_hour = hourly_weather;
            actual_weather.per_week = week_weather;

        }
        public Overtime ovetimes (Weather actual_weather, int interval){

            int temp = actual_weather.TemperatureC;
            int hum = actual_weather.Humidity;

            Overtime timed = new Overtime(){
                date = DateTime.Now.AddHours(interval),
                TemperatureC = throw_dice(temp -2,temp + 2),
                Humidity = throw_dice(hum - 10, hum + 10)
            };
            timed.SkyView = sky_aparence(timed.TemperatureC);
            System.Console.WriteLine(timed.date);

            while (timed.Humidity < 0 || timed.Humidity > 100) { timed.Humidity += throw_dice(hum -5, hum +5); };
            
            return timed;
        }
        public string sky_aparence(int temperature)
        {
            List<string> HighTemp = new List<string>(){"Sunny", "Partly Cloudy", "Sunny", "Sunny", "Partly Cloudy"};
            List<string> MildTemp = new List<string>(){"Cloudy", "Partly Cloudy", "Windy", "Sunny", "Rainy"};
            List<string> LowTemp = new List<string>(){"Cloudy", "Partly Cloudy", "Windy", "Foggy", "Snowy"};
            
            switch(temperature)
            {
                case > 23:
                return HighTemp[throw_dice(0 , HighTemp.Count())];

                case <= 0:
                return LowTemp[throw_dice(0 , LowTemp.Count())];

                default:
                return MildTemp[throw_dice(0 , MildTemp.Count())];
            }

        }
        public int throw_dice(int min, int max){
            Random num = new Random();
            return num.Next(min, max);
        }

    }
};