using System;

namespace humiditymonitor2.WeatherData.Classes
{
    public class Weather
    {
        public int Id { get; set; }
        public String Main { get; set; }
        public String Description { get; set; }
        public String Icon { get; set; }
    }
}