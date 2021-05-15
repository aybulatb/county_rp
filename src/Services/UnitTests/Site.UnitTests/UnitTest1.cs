using CountyRP.Services.Site.Controllers;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;
using CountyRP.Services.Site.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Site.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "1",
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.AddUserAsync(It.IsAny<UserDtoIn>()))
                .ReturnsAsync(It.IsAny<UserDtoOut>());

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Длина логина пользователя должна быть от 3 до 32 символов", responseObject);
        }
    }
}
