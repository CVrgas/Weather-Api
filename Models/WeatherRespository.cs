namespace WeatherApi.Models
{
    public class WeatherRepository : IWeatherRepository
    {
        public Weather GetWeather(string city)
        {
            int temp = new_temp_hum("temp");
            int hum = new_temp_hum("hum");

            Weather nullweather = new Weather() ;

            Weather targetLocation = new Weather 
            { 
                Location = city,
                localtime = DateTime.Now,
                TemperatureC = temp, 
                Humidity = hum,
                SkyView = sky_aparence(temp),
                per_hour = Weather_Overtime(temp, hum, false),
                per_week = Weather_Overtime(temp, hum, true)
            };

            return targetLocation;
        }

        public int new_temp_hum(string type)
        {
            Random num = new Random();
            switch(type)
            {
                case "temp":
                return num.Next(-10, 40);

                case "hum":
                return num.Next(50, 100);

                default:
                throw new ArgumentException();
            }
        }
        public int RandomNum(int based, string type)
        {
            Random num = new Random();

            switch(type)
            {
                case "temp":
                return num.Next(based - 2, based + 2);

                case "hum":
                int hum = num.Next(based - 10, based + 10);
                if( hum < 0 )
                {
                    return hum + 5;
                }
                return hum;

                case "sky":
                return num.Next (0, 5);

                default:
                throw new ArgumentException();
            }
        }
        public List<Overtime> Weather_Overtime(int temperature, int Humidity, bool Is_daily)
        {
            List<Overtime> lies_per_hour = new List<Overtime>();
            int How_many = 5;

            if(Is_daily)
            {
                How_many = 7;
            }
            
            for (int i = 1; i < How_many; i++)
            {
                Overtime hourly = new Overtime()
                {
                    date = date(Is_daily, i),
                    TemperatureC= RandomNum(temperature, "temp"), 
                    Humidity= RandomNum(Humidity, "temp"), 
                    SkyView = sky_aparence(temperature)
                };
                lies_per_hour.Add(hourly);
            }
            return lies_per_hour;
        }
        public string sky_aparence(int temperature)
        {
            List<string> HighTemp = new List<string>(){"Sunny", "Partly Cloudy", "Sunny", "Sunny", "Partly Cloudy"};
            List<string> MildTemp = new List<string>(){"Cloudy", "Partly Cloudy", "Windy", "Sunny", "Rainy"};
            List<string> LowTemp = new List<string>(){"Cloudy", "Partly Cloudy", "Windy", "Foggy", "Snowy"};

            // Cloudy, Partly Cloudy, Windy, Sunny, Rainy, Foggy, Snowy

            switch(temperature)
            {
                case > 23:
                return HighTemp[RandomNum(temperature,  "sky")];

                case <= 0:
                return LowTemp[RandomNum(temperature, "sky")];

                default:
                return MildTemp[RandomNum(temperature, "sky")];
            }

        }
        public DateTime date(bool Is_daily, int i)
        {
            DateTime date = DateTime.Now;
            switch(Is_daily)
            {
                case true:
                    return date.AddDays(i);

                default:
                    return date.AddHours(i);
            }
        }

    }
};