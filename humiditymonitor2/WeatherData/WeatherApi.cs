using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using humiditymonitor2.WeatherData.Classes;

namespace humiditymonitor2.WeatherData
{
    public static class WeatherApi
    {

        private static HttpClient _client;

        public static void Init()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Data> GetDataAsync(string zip, string appId)
        {
            if (_client == null)
            {
                Init();
            }

            Data data = null;
            HttpResponseMessage response = await _client.GetAsync($"weather?zip={zip}&appid={appId}");
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<Data>();
            }

            return data;
        }
    }
}