//X00114185 -  Kadrieh Mohamadzadeh
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAD2_Repeat.Models
{
    //public enum WindCondition
    //{
    //    Sunny, Cloudy, Overcast, Rain, Drizzle, Fog, Snow
    //}

    //public enum WindDirection
    //{
    //    North, South, East, West, Northeast, Southeast, Northwest, Southwest
    //}

    public class Weather
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string WindDirection { get; set; }

        [Required]
        public string WeatherCondition { get; set; }

        [Required]
        [Range(-40, 40, ErrorMessage = "Maximum temperature. should be between -40 and 40")]
        public int MaxTemp { get; set; }

        [Required]
        [Range(-40, 40, ErrorMessage = "Minimum temperature. should be between -40 and 40")]
        public int MinTemp { get; set; }

        [Required]
        [Range(0, 200, ErrorMessage = "Wind Speed should be between 0 to 200")]
        public int WindSpeed { get; set; }

        public string NextDayWeather { get; set; }

        private DateTime _DefaultDate = DateTime.Now;

        public DateTime WeatherDate
        {
            get
            {
                return _DefaultDate;
            }
            set
            {
                _DefaultDate = value;
            }
        }
    }
}