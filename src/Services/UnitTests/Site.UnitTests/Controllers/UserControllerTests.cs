using AutoFixture;
using CountyRP.Services.Site.Controllers;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;
using CountyRP.Services.Site.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Site.UnitTests.Controllers
{
    public class UserControllerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("1234567890testlogin1234567890testlogin")]
        public async Task Create_Given_login_is_less_than_3_or_more_than_32_When_result_is_badrequest_Then_success(string login)
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

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

        [Theory]
        [InlineData("привет")]
        [InlineData(" Whitespace")]
        [InlineData("Whitespace ")]
        [InlineData("test test test test")]
        [InlineData("test!")]
        [InlineData("test@)")]
        public async Task Create_Given_login_has_invalid_symbols_When_result_is_badrequest_Then_success(string login)
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Логин пользователя должен состоять из цифр, символов латинского алфавита и специальных символов", responseObject);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1")]
        [InlineData("1234567")]
        [InlineData("1234567890testlogin1234567890testlogin1234567890testlogin1234567890testlogin")]
        public async Task Create_Given_password_is_less_than_8_or_more_than_64_When_result_is_badrequest_Then_success(string password)
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
                Password = password,
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Длина пароля должна быть от 8 до 64 символов", responseObject);
        }

        [Theory]
        [InlineData("123привет")]
        [InlineData("123123123'")]
        [InlineData("123123123\"")]
        [InlineData("123123123 123")]
        public async Task Create_Given_password_has_invalid_symbols_When_result_is_badrequest_Then_success(string password)
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
                Password = password,
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Пароль должен состоять из символов латинского алфавита и специальных символов", responseObject);
        }

        [Fact]
        public async Task Create_Given_user_with_same_login_exists_When_result_is_badrequest_Then_success()
        {
            // Arrange
            var fixture = new Fixture();
            var login = "123";

            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var userDtoOut = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByLoginAsync(login))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Пользователь с таким логином уже существует", responseObject);
        }

        [Fact]
        public async Task Create_Given_user_with_right_data_exists_When_result_is_ok_Then_success()
        {
            // Arrange
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var userDtoOut = new UserDtoOut(
                id: 1,
                login: "123",
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.AddUserAsync(It.IsAny<UserDtoIn>()))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Create(apiUserDtoIn);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var responseObject = Assert.IsType<ApiUserDtoOut>(createdResult.Value);
            Assert.Equal(1, responseObject.Id);
            Assert.Equal(apiUserDtoIn.Login, responseObject.Login);
        }
    }
}
