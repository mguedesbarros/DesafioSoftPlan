using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CalculoJurosAPI.IntegrationTest
{
    public class CalculoJurosIntegrationTest
    {
        private readonly HttpClient _client;

        public CalculoJurosIntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<CalculoJurosAPI.Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task CalculoJurosGetTestAsync(string method)
        {

            // Arrange
            var valorInicial = 100;
            var meses = 5;
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/CalculoJuros/valorInicial/{valorInicial}/meses/{meses}");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("105.10", stringResponse);
        }
    }
}
