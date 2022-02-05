using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Trouvtou.Tests
{
    public class ObjetsControllerTests
    : IClassFixture<WebApplicationFactory<Trouvtou.Startup>>
    {
        private readonly WebApplicationFactory<Trouvtou.Startup> _factory;

        public ObjetsControllerTests(WebApplicationFactory<Trouvtou.Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/")]
        [InlineData("/  Objets/Index")]
        [InlineData("/Objets/Details")]
        [InlineData("/Objets/Delete")]
        [InlineData("/Objets/Edit")]
        [InlineData("/Objets/Create")]

        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }

    public class RangementControllerTests
    : IClassFixture<WebApplicationFactory<Trouvtou.Startup>>
    {
        private readonly WebApplicationFactory<Trouvtou.Startup> _factory;

        public RangementControllerTests(WebApplicationFactory<Trouvtou.Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/")]
        [InlineData("/Rangement/Index")]
        [InlineData("/Rangement/Details")]
        [InlineData("/Rangement/Delete")]
        [InlineData("/Rangement/Edit")]
        [InlineData("/Rangement/Create")]

        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}