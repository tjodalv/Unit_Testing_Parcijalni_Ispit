using aspnet_core_unit_1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace aspnet_core_unit_1.Tests
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;
        private readonly Mock<ILogger<HomeController>> _mockLogger = new Mock<ILogger<HomeController>>();

        public HomeControllerTests()
        {
            // Kreiraj objekt HomeController klase koji cemo testirati i predaj mu mocked logger objekt
            _controller = new HomeController(_mockLogger.Object);
        }

        [Fact]
        public void CheckCountValue_BrojVeciOd20_BacaException()
        {
            int testValue = 500;

            // Ocekujemo da funkcija baci exception
            var ex = Assert.Throws<Exception>(() => _controller.CheckCountValue(testValue));

            Assert.Equal("Broj je izvan raspona", ex.Message);
        }

        [Fact]
        public void CheckCountValue_BrojManjiOd20_VracaViewResult()
        {
            int testValue = 2;

            var result = _controller.CheckCountValue(testValue);

            // Provjeri da smo dobili objekt tipa ViewResult
            Assert.IsType<ViewResult>(result);
        }
    }
}