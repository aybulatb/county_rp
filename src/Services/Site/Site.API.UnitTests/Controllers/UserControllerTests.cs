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

        [Fact]
        public async Task GetById_Given_not_existed_user_When_result_is_notfound_Then_success()
        {
            // Arrange
            var id = 10;

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.GetById(id);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundObjectResult.Value);
            Assert.Equal("Пользователь с ID 10 не найден", responseObject);
        }

        [Fact]
        public async Task GetById_Given_existed_user_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var userDtoOut = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.GetById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiUserDtoOut>(okObjectResult.Value);
        }

        [Fact]
        public async Task GetByLogin_Given_not_existed_user_When_result_is_notfound_Then_success()
        {
            // Arrange
            var login = "123";

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.GetByLogin(login);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundObjectResult.Value);
            Assert.Equal("Пользователь с логином 123 не найден", responseObject);
        }

        [Fact]
        public async Task GetByLogin_Given_existed_user_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var login = "123";
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
            var result = await userController.GetByLogin(login);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiUserDtoOut>(okObjectResult.Value);
        }

        [Fact]
        public async Task Authenticate_Given_not_existed_user_When_result_is_notfound_Then_success()
        {
            // Arrange
            var login = "123";
            var password = "123123123";

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Authenticate(login, password);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundObjectResult.Value);
            Assert.Equal("Пользователь с таким логином и паролем не найден", responseObject);
        }

        [Fact]
        public async Task Authenticate_Given_existed_user_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var login = "123";
            var password = "123123123";
            var userDtoOut = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.AuthenticateAsync(login, password))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Authenticate(login, password);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiUserDtoOut>(okObjectResult.Value);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(105)]
        public async Task FilterBy_Given_count_is_less_than_1_or_more_than_100_When_result_is_badrequest_Then_success(int count)
        {
            // Arrange
            var apiUserFilterDtoIn = new ApiUserFilterDtoIn
            {
                Count = count,
                Page = 1
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.FilterBy(apiUserFilterDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Количество записей на странице должно быть от 1 до 100", responseObject);
        }

        [Fact]
        public async Task FilterBy_Given_page_is_less_than_1_When_result_is_badrequest_Then_success()
        {
            // Arrange
            var page = 0;
            var apiUserFilterDtoIn = new ApiUserFilterDtoIn
            {
                Count = 5,
                Page = page
            };

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.FilterBy(apiUserFilterDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Номер страницы должен быть 1 и выше", responseObject);
        }

        [Fact]
        public async Task FilterBy_Given_right_params_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var apiUserFilterDtoIn = new ApiUserFilterDtoIn
            {
                Count = 5,
                Page = 1
            };
            var pagedFilterResult = fixture.Create<PagedFilterResult<UserDtoOut>>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUsersByFilterAsync(It.IsAny<UserFilterDtoIn>()))
                .ReturnsAsync(pagedFilterResult);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.FilterBy(apiUserFilterDtoIn);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiPagedFilterResult<ApiUserDtoOut>>(okObjectResult.Value);
        }

        [Fact]
        public async Task Edit_Given_not_existed_user_When_result_is_notfound_Then_success()
        {
            // Arrange
            var id = 10;
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
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
            var result = await userController.Edit(id, apiUserDtoIn);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundObjectResult.Value);
            Assert.Equal("Пользователь с ID 10 не найден", responseObject);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("1234567890testlogin1234567890testlogin")]
        public async Task Edit_Given_login_is_less_than_3_or_more_than_32_When_result_is_badrequest_Then_success(string login)
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

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
        public async Task Edit_Given_login_has_invalid_symbols_When_result_is_badrequest_Then_success(string login)
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

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
        public async Task Edit_Given_password_is_less_than_8_or_more_than_64_When_result_is_badrequest_Then_success(string password)
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
                Password = password,
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

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
        public async Task Edit_Given_password_has_invalid_symbols_When_result_is_badrequest_Then_success(string password)
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = "123",
                Password = password,
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Пароль должен состоять из символов латинского алфавита и специальных символов", responseObject);
        }

        [Fact]
        public async Task Edit_Given_user_with_same_login_exists_and_different_id_When_result_is_badrequest_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var existedUserId = 11;
            var login = "123";
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = new UserDtoOut(
                id: id,
                login: login,
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );
            var existedUserWithId = new UserDtoOut(
                id: existedUserId,
                login: login,
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);
            siteRepository
                .Setup(s => s.GetUserByLoginAsync(login))
                .ReturnsAsync(existedUserWithId);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Пользователь с таким логином уже существует", responseObject);
        }

        [Fact]
        public async Task Edit_Given_user_with_right_data_exists_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var existedUserId = 10;
            var login = "123";
            var apiUserDtoIn = new ApiUserDtoIn
            {
                Login = login,
                Password = "123123123",
                GroupId = "group",
                PlayerId = 1,
                ForumUserId = 2
            };
            var existedUser = new UserDtoOut(
                id: id,
                login: login,
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );
            var existedUserWithId = new UserDtoOut(
                id: existedUserId,
                login: login,
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );
            var userDtoOut = new UserDtoOut(
                id: id,
                login: login,
                password: "123123123",
                playerId: 1,
                forumUserId: 2,
                groupId: "group"
            );

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(existedUser);
            siteRepository
                .Setup(s => s.GetUserByLoginAsync(login))
                .ReturnsAsync(existedUserWithId);
            siteRepository
                .Setup(s => s.UpdateUserAsync(It.IsAny<UserDtoOut>()))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Edit(id, apiUserDtoIn);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiUserDtoOut>(okObjectResult.Value);
            Assert.Equal(id, responseObject.Id);
            Assert.Equal(apiUserDtoIn.Login, responseObject.Login);
        }

        [Fact]
        public async Task Delete_Given_not_existed_user_When_result_is_notfound_Then_success()
        {
            // Arrange
            var id = 10;

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Delete(id);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundObjectResult.Value);
            Assert.Equal("Пользователь с ID 10 не найден", responseObject);
        }

        [Fact]
        public async Task Delete_Given_existed_user_When_result_is_ok_Then_success()
        {
            // Arrange
            var fixture = new Fixture();

            var id = 10;
            var userDtoOut = fixture.Create<UserDtoOut>();

            var logger = new Mock<ILogger<UserController>>();
            var siteRepository = new Mock<ISiteRepository>();
            siteRepository
                .Setup(s => s.GetUserByIdAsync(id))
                .ReturnsAsync(userDtoOut);

            var userController = new UserController(
                logger: logger.Object,
                siteRepository: siteRepository.Object
            );

            // Act
            var result = await userController.Delete(id);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }
    }
}
