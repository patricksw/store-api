using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Functional.WebApi.Features
{
    public class UserFunctionalFlowTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserFunctionalFlowTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task UserValidCanCreateCartAndAddProducts()
        {
            // User
            var userId = new Guid("55dc73a6-e35f-45e3-9189-6a6ec64763f6"); // Use a valid user ID from your database
            var response = await _client.GetAsync($"/api/users/{userId}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Create cart
            var request = new
            {
                UserId = userId,
                Date = DateTime.UtcNow,
                Branch = 1,
                Products = new[]
                {
                    new { ProductId = new Guid("91b1af81-8c7f-4733-aa78-92e90b4bc6dd"), Quantity = 3, UnitPrice = 7.89m },
                    new { ProductId = new Guid("885a23cc-80f7-4aba-9fbc-4b1506b344ec"), Quantity = 2, UnitPrice = 8.78m } // Use valid product IDs from your database
                }
            };

            var cartResponse = await _client.PostAsJsonAsync("/api/carts", request);
            cartResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            // Add product to cart
            var productRequest = new
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

            var productResponse = await _client.PostAsJsonAsync("/api/products", productRequest);
            productResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }
    }
}