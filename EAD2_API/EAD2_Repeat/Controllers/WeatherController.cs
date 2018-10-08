//X00114185 -  Kadrieh Mohamadzadeh
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EAD2_Repeat.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EAD2_Repeat.Controllers
{

    public class WeatherController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        //private List<Weather> getWeather(DatabaseContext context)
        //{
        //    new Weather { ID = 1, CityName = "Dublin", WindDirection = WindDirection.East, WindCondition = WindCondition.Cloudy, MinTemp = 13, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Clody", WeatherDate = DateTime.Now },
        //    new Weather { ID = 2, CityName = "Galway", WindDirection = WindDirection.West, WindCondition = WindCondition.Drizzle, MinTemp = 13, MaxTemp = 15, WindSpeed = 75, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
        //    new Weather { ID = 3, CityName = "Cork", WindDirection = WindDirection.Southeast, WindCondition = WindCondition.Fog, MinTemp = 15, MaxTemp = 19, WindSpeed = 105, NextDayWeather = "Snow", WeatherDate = DateTime.Now },
        //    new Weather { ID = 4, CityName = "Limerick", WindDirection = WindDirection.Southwest, WindCondition = WindCondition.Rain, MinTemp = 10, MaxTemp = 13, WindSpeed = 107, NextDayWeather = "Cloudy", WeatherDate = DateTime.Now },
        //    new Weather { ID = 5, CityName = "Donegal", WindDirection = WindDirection.North, WindCondition = WindCondition.Overcast, MinTemp = 9, MaxTemp = 11, WindSpeed = 109, NextDayWeather = "Snow", WeatherDate = DateTime.Now },
        //    new Weather { ID = 6, CityName = "Kildare", WindDirection = WindDirection.West, WindCondition = WindCondition.Snow, MinTemp = 13, MaxTemp = 15, WindSpeed = 99, NextDayWeather = "Drizzle", WeatherDate = DateTime.Now },
        //    new Weather { ID = 7, CityName = "Sligo", WindDirection = WindDirection.Northwest, WindCondition = WindCondition.Sunny, MinTemp = 15, MaxTemp = 19, WindSpeed = 87, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
        //    new Weather { ID = 8, CityName = "Meath", WindDirection = WindDirection.Southeast, WindCondition = WindCondition.Cloudy, MinTemp = 11, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Windy", WeatherDate = DateTime.Now },
        //    new Weather { ID = 9, CityName = "Wicklow", WindDirection = WindDirection.North, WindCondition = WindCondition.Cloudy, MinTemp = 13, MaxTemp = 17, WindSpeed = 77, NextDayWeather = "Rainy", WeatherDate = DateTime.Now },
        //    new Weather { ID = 10, CityName = "Waterford", WindDirection = WindDirection.West, WindCondition = WindCondition.Fog, MinTemp = 13, MaxTemp = 17, WindSpeed = 85, NextDayWeather = "Cloudy", WeatherDate = DateTime.Now },  
        //}

        //Get
        public HttpResponseMessage Get(string city)
        {
            
            HttpResponseMessage responseMessage;

            using (DatabaseContext con = new DatabaseContext())
            {
                var result = con.Weathers.Where(a => a.CityName.ToUpper().Equals(city.ToUpper())
                                                ).OrderByDescending(a => a.WeatherDate).FirstOrDefault();

                if (result == null)
                {
                    var message = string.Format("No weather information available for this  {0} and {1}", city);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
                else
                    responseMessage = Request.CreateResponse(HttpStatusCode.OK, result);
            }
                return responseMessage;
        }

    }
}
