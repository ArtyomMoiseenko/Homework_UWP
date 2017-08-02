using Homework_UWP.Models;
using Homework_UWP.Services.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homework_UWP.Services
{
    public class WeatherService
    {
        private readonly string _baseUrl;

        public WeatherService()
        {
            _baseUrl = "localhost:5000";
        }

        public async Task<WeatherModel> GetWeatherCity(string city, string countDays)
        {
            var url = $"{_baseUrl}/api/ForecastWeather?nameCity={city}&countDays={countDays}";
            WeatherModel weather;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                weather = JsonConvert.DeserializeObject<WeatherModel>(json);
            }

            return weather;
        }
    }
}
