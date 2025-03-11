using Ambev.DeveloperEvaluation.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration.WebApi.Features.Users
{
    public class UsersControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UsersControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_ShouldReturnCreated()
        {
            int randSuffix = new Random().Next(1, 999);
            var request = new
            {
                Username = $"user_testambev{randSuffix}",
                Password = "c@Nn1$1T",
                Phone = "51997859991",
                Email = $"user_testambev{randSuffix}@gmail.com",
                Status = 1,
                Role = 1
            };

            var response = await _client.PostAsJsonAsync("/api/users", request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetUser_ShouldReturnOk()
        {
            var userId = new Guid("55dc73a6-e35f-45e3-9189-6a6ec64763f6"); // Use a valid user ID from your database
            var response = await _client.GetAsync($"/api/users/{userId}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}