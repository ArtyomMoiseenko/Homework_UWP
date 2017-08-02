using Homework_UWP.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homework_UWP.Services
{
    public class LogService
    {
        private readonly string _baseUrl;

        public LogService()
        {
            _baseUrl = "localhost:5000";
        }

        public async Task<LogModel> GetLogs()
        {
            var url = $"{_baseUrl}/api/Log";
            LogModel logs;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                logs = JsonConvert.DeserializeObject<LogModel>(json);
            }

            return logs;
        }
    }
}
