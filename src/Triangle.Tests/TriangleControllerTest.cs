using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using TriangleAPI;

namespace Triangle.API.Tests
{
    public class TriangleControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        readonly HttpClient _client;
        public TriangleControllerTest(WebApplicationFactory<Program> webApplication)
        {
            _client = webApplication.CreateClient();
        }

        [Fact]
        public async Task ShouldGetMaximumTotalTriangle()
        {
            //Act
            var response = await _client.GetAsync("api/triangle/getmaximumtotaltriangle");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}