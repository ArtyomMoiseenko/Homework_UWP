using Homework_UWP.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homework_UWP.Services
{
    public class LogService
    {
        private readonly string _baseUrl;

        public LogService()
        {
            _baseUrl = $"http://localhost:50624";
        }

        public async Task<IEnumerable<LogModel>> GetLogs()
        {
            var url = $"{_baseUrl}/api/Log";
            IEnumerable<LogModel> logs;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                logs = JsonConvert.DeserializeObject<IEnumerable<LogModel>>(json);
            }

            return logs;
        }
    }
}
