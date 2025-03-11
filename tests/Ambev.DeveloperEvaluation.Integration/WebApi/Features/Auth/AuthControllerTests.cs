using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Features.Auth
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AuthenticateUser_ShouldReturnOk()
        {
            var request = new
            {
                Email = "patricksilva.sw@gmail.com",
                Password = "c@Nn1$1T"
            };

            var response = await _client.PostAsJsonAsync("/api/auth", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}