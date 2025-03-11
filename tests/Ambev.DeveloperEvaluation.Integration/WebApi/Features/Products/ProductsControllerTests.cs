using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Features.Products
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnCreated()
        {
            var request = new
            {
                Title = "cerveja",
                Price = 4.99,
                Description = "top cerveja ambev",
                Category = "bebida",
                Image = "c:/temp/beer.png",
                Rating = new
                {
                    Rate = 4.93,
                    Count = 19
                }
            };

            var response = await _client.PostAsJsonAsync("/api/products", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetAllProduct_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/products");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
