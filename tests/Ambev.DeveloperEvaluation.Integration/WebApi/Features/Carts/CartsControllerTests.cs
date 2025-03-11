using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Features.Carts
{
    public class CartsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CartsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateCart_ShouldReturnCreated()
        {
            var request = new
            {
                UserId = new Guid("55dc73a6-e35f-45e3-9189-6a6ec64763f6"), // Use a valid user ID from your database
                Date = DateTime.UtcNow,
                Branch = 1,
                Products = new[]
                {
                    new { ProductId = new Guid("91b1af81-8c7f-4733-aa78-92e90b4bc6dd"), Quantity = 3, UnitPrice = 7.89m },
                    new { ProductId = new Guid("885a23cc-80f7-4aba-9fbc-4b1506b344ec"), Quantity = 2, UnitPrice = 8.78m } // Use valid product IDs from your database
                }
            };

            var response = await _client.PostAsJsonAsync("/api/carts", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetAllCart_ShouldReturnOk()
        {
            var response = await _client.GetAsync($"/api/carts");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}