namespace EAD2_Repeat.Migrations
{
    using EAD2_Repeat.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EAD2_Repeat.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EAD2_Repeat.Models.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var weather = new List<Weather>()
            {
            new Weather { ID = 1, CityName = "Dublin", WindDirection = "North", WeatherCondition ="Sunny", MinTemp = 13, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Cloudy", WeatherDate = DateTime.Now },
            new Weather { ID = 2, CityName = "Galway", WindDirection = "West", WeatherCondition = "Drizzle", MinTemp = 13, MaxTemp = 15, WindSpeed = 75, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
            new Weather { ID = 3, CityName = "Cork", WindDirection = "Southeast", WeatherCondition = "Fog", MinTemp = 15, MaxTemp = 19, WindSpeed = 105, NextDayWeather = "Snow", WeatherDate = DateTime.Now },
            new Weather { ID = 4, CityName = "Limerick", WindDirection = "Southwest", WeatherCondition = "Rainy", MinTemp = 10, MaxTemp = 13, WindSpeed = 107, NextDayWeather = "Cloudy", WeatherDate = DateTime.Now },
            new Weather { ID = 5, CityName = "Donegal", WindDirection = "North", WeatherCondition = "Overcast", MinTemp = 9, MaxTemp = 11, WindSpeed = 109, NextDayWeather = "Snow", WeatherDate = DateTime.Now },
            new Weather { ID = 6, CityName = "Kildare", WindDirection = "West", WeatherCondition = "Snow", MinTemp = 13, MaxTemp = 15, WindSpeed = 99, NextDayWeather = "Drizzle", WeatherDate = DateTime.Now },
            new Weather { ID = 7, CityName = "Sligo", WindDirection = "Northwest", WeatherCondition = "Sunny", MinTemp = 15, MaxTemp = 19, WindSpeed = 87, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
            new Weather { ID = 8, CityName = "Meath", WindDirection = "Southeast", WeatherCondition = "Cloudy", MinTemp = 11, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Windy", WeatherDate = DateTime.Now },
            new Weather { ID = 9, CityName = "Wicklow", WindDirection = "North", WeatherCondition = "Cloudy", MinTemp = 13, MaxTemp = 17, WindSpeed = 77, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
            new Weather { ID = 10, CityName = "Waterford", WindDirection = "West", WeatherCondition = "Fog", MinTemp = 13, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Cloudy", WeatherDate = DateTime.Now },
            };

            weather.ForEach(s => context.Weathers.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }
    }
}
