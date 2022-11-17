using System;

namespace humiditymonitor2.WeatherData.Classes
{
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public String Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}