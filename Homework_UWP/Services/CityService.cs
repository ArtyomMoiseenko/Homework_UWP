using Homework_UWP.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Homework_UWP.Services
{
    public class CityService
    {
        private readonly string _baseUrl;

        public CityService()
        {
            _baseUrl = "localhost:5000";
        }

        public async Task<CityModel> GetCities()
        {
            var url = $"{_baseUrl}/api/Cities";
            CityModel cities;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<CityModel>(json);
            }

            return cities;
        }

        public async Task<CityModel> GetCity(int id)
        {
            var url = $"{_baseUrl}/api/Cities/{id}";
            CityModel city;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                city = JsonConvert.DeserializeObject<CityModel>(json);
            }

            return city;
        }

        public async Task<HttpResponseMessage> CreateCity(CityModel city)
        {
            HttpResponseMessage response;
            var url = $"{_baseUrl}/api/Cities";
            var jsonString = JsonConvert.SerializeObject(city);

            using (var client = new HttpClient())
            {
                using (HttpContent httpContent = new StringContent(jsonString))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(url, httpContent);
                }
            }

            return response;
        }

        public async Task<HttpResponseMessage> EditCity(int id, CityModel city)
        {
            HttpResponseMessage response;
            var url = $"{_baseUrl}/api/Cities/{id}";
            var jsonString = JsonConvert.SerializeObject(city);

            using (var client = new HttpClient())
            {
                using (HttpContent httpContent = new StringContent(jsonString))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PutAsync(url, httpContent);
                }
            }

            return response;
        }

        public async Task<HttpResponseMessage> DeleteCity(int id)
        {
            var url = $"{_baseUrl}/api/Cities/{id}";
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                response = await client.DeleteAsync(url);
            }

            return response;
        }
    }
}
