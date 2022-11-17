using System;
using System.Threading.Tasks;
using humiditymonitor2.WeatherData;
using humiditymonitor2.WeatherData.Classes;
using Microsoft.Extensions.Configuration;

namespace humiditymonitor2
{

    class Program
    {
        static async Task RunAsync()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            Data data = await WeatherApi.GetDataAsync(config["zipCode"], config["appId"]);
            int humidity = data.Main.Humidity;

            if (humidity < 20)
            {
                Emailer emailer = new Emailer(config["smtpHost"], config["mailUser"], config["password"]);
                emailer.Send(config["fromAddress"], config["recipient"], "Weather Alert", "Humidity is " + humidity);
            }
        }

        static void Main(string[] args)
        {
            System.Timers.Timer timer = new(interval: 60 * 60 * 1000);
            try
            {
                timer.Elapsed += (sender, e) => RunAsync().GetAwaiter().GetResult();
                timer.Start();
            }
            catch(Exception e)
            {
                timer.Dispose();
                Console.WriteLine(e.Message);
            }
        }
    }
}
