using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Platform.HttpCommand
{
    public class ClientCommand : IClientCommand
    {
        private IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientCommand(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task Post(string message)
        {
            var api = _configuration.GetSection("CommandServiceApi").Value;
            
            var httpClient = _httpClientFactory.CreateClient();
            HttpContent httpContent = new StringContent(
                JsonSerializer.Serialize(message), encoding: Encoding.UTF8, Application.Json
            );
            var response = await httpClient.PostAsync(api, httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Result from external api {0}", response.StatusCode);
            }
            return;
        }
    }
}