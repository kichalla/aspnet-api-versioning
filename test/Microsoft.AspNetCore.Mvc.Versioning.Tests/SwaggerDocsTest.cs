using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Microsoft.AspNetCore.Mvc
{
    public class SwaggerDocsTest
        : IClassFixture<WebApplicationFactory<Microsoft.Examples.Startup>>
    {
        private readonly WebApplicationFactory<Microsoft.Examples.Startup> _factory;

        public SwaggerDocsTest( WebApplicationFactory<Microsoft.Examples.Startup> factory )
        {
            _factory = factory;
        }

        [Fact]
        public async Task GeneratesSwaggerDoc()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("swagger/v3/swagger.json");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var data = await response.Content.ReadAsStringAsync();

        }
    }
}
