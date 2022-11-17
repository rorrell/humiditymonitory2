using System;
using System.Collections.Generic;

namespace humiditymonitor2.WeatherData.Classes
{
    public class Data
    {
        public Coord Coord { get; set; }
        public List<Weather> Weathers { get; set; }
        public String Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public int Cod { get; set; }
    }
}