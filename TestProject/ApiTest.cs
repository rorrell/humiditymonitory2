using humiditymonitor2.WeatherData;
using humiditymonitor2.WeatherData.Classes;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class ApiTest
    {
        private IConfigurationRoot config;
        private Data data;

        [SetUp]
        public void SetUp()
        {
            config = new ConfigurationBuilder().AddUserSecrets<ApiTest>().Build();
            data = WeatherApi.GetDataAsync(config["zipCode"], config["appId"]).Result;
        }

        [Test]
        public void DataIsReturned()
        {
            Assert.IsNotNull(data);
        }

            [Test]
        public void HumidityIsPresent()
        {
            Assert.Greater(data.Main.Humidity, -1);
        }
    }
}