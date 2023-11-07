using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

namespace Kujira
{
    public class HttpClientFactory
    {
        private readonly IWebAssemblyHostEnvironment _environment;

        public HttpClientFactory(IWebAssemblyHostEnvironment environment)
        {
            _environment = environment;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(_environment.BaseAddress) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
