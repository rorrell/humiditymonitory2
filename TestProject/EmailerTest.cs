using System;
using humiditymonitor2;
using humiditymonitor2.WeatherData;
using humiditymonitor2.WeatherData.Classes;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class EmailerTest
    {
        private IConfigurationRoot config;
        private Emailer emailer;

        [SetUp]
        public void SetUp()
        {
            config = new ConfigurationBuilder().AddUserSecrets<EmailerTest>().Build();
            emailer = new Emailer(config["smtpHost"], config["mailUser"], config["password"]);
        }

        [Test]
        public void SendDoesNotFail()
        {
            try
            {
                emailer.Send(config["fromAddress"], config["recipient"], "Testing", "This is a test");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.IsTrue(true);
        }
    }
}