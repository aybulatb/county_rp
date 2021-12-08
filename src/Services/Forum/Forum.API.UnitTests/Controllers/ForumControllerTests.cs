using AutoFixture;
using CountyRP.Services.Forum.API.Controllers;
using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;
using CountyRP.Services.Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CountyRP.Services.Forum.UnitTests
{
    public class ForumControllerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234thisislongname1231234thisislongname1231234thisislongname1231234thisislongname1231234thisislongname123")]
        public async Task Create_Given_name_is_less_than_1_or_more_than_96_or_null_When_result_is_badRequest_Then_success(string name)
        {
            // Arrange
            var apiForumDtoIn = new ApiForumDtoIn
            {
                Name = name,
                Order = 1,
                ParentId = 2
            };

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );

            // Act

            var result = await forumController.Create(apiForumDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Длина названия форума должна быть от 1 до 96 символов", responseObject);
        }

        [Fact]
        public async Task Create_Given_forum_with_right_data_When_result_is_ok_Then_success()
        {
            // Arrange
            var apiForumDtoIn = new ApiForumDtoIn
            {
                Name = "test1",
                Order = 1,
                ParentId = 2
            };

            var forumDtoOut = new ForumDtoOut(
                id: 1,
                name: "test1",
                parentId: 2,
                order: 1
            );

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();
            forumRepository
                .Setup(f => f.CreateForumAsync(It.IsAny<ForumDtoIn>()))
                .ReturnsAsync(forumDtoOut);

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );

            // Act

            var result = await forumController.Create(apiForumDtoIn);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var responseObject = Assert.IsType<ApiForumDtoOut>(createdResult.Value);
            Assert.Equal(1, responseObject.Id);
            Assert.Equal(apiForumDtoIn.Name, responseObject.Name);
        }

        [Fact]
        public async Task Get_Given_forums_exist_When_result_is_ok_Then_success()
        {
            // Arrange
            var forumsDtoOut = new List<ForumDtoOut>
            {
                new ForumDtoOut(id: 1, name: "test1", parentId: 2, order: 1),
                new ForumDtoOut(id: 2, name: "test2", parentId: 2, order: 2),
                new ForumDtoOut(id: 3, name: "test3", parentId: 2, order: 3),
            };

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();
            forumRepository
                .Setup(f => f.GetForumsAsync())
                .ReturnsAsync(forumsDtoOut);

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsAssignableFrom<IEnumerable<ApiForumDtoOut>>(okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_Given_forum_not_exist_When_result_is_notfound_Then_success()
        {
            // Arrange
            var id = 111;

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.GetById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseObject = Assert.IsType<string>(notFoundResult.Value);
            Assert.Equal("Форум с ID 111 не найден", responseObject);
        }

        [Fact]
        public async Task GetById_Given_forum_exist_When_result_is_ok_Then_success()
        {
            // Arrange
            var id = 1;

            var apiForumDtoOut = new ApiForumDtoOut
            {
                Id = 1,
                Name = "test1",
                Order = 1,
                ParentId = 2
            };

            var forumDtoOut = new ForumDtoOut(
                id: 1,
                name: "test1",
                parentId: 2,
                order: 1
            );

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();
            forumRepository
                .Setup(f => f.GetForumByIdAsync(id))
                .ReturnsAsync(forumDtoOut);

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.GetById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiForumDtoOut>(okObjectResult.Value);
            Assert.Equal(1, responseObject.Id);
            Assert.Equal(apiForumDtoOut.Name, responseObject.Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public async Task FilterBy_Given_count_is_less_than_1_or_more_than_100_When_result_is_badrequest_Then_success(int count)
        {
            // Arrange
            var apiForumFilterDtoIn = new ApiForumFilterDtoIn
            {
                Count = count,
                Page = 1,
                ParentIds = new[] { 1 }
            };

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.FilterBy(apiForumFilterDtoIn);

            // Assert
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseObject = Assert.IsType<string>(badRequestObjectResult.Value);
            Assert.Equal("Количество страниц должно быть от 1 до 100", responseObject);
        }

        [Fact]
        public async Task FilterBy_Given_page_is_less_than_1_When_result_is_badrequest_Then_success()
        {
            // Arrange
            var page = 0;
            var apiForumFilterDtoIn = new ApiForumFilterDtoIn
            {
                Count = 5,
                Page = page,
                ParentIds = new[] { 1 }
            };

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.FilterBy(apiForumFilterDtoIn);

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

            var apiForumFilterDtoIn = new ApiForumFilterDtoIn
            {
                Count = 5,
                Page = 1,
                ParentIds = new[] { 1 }
            };

            var pagedFilterResult = fixture.Create<PagedFilterResult<ForumDtoOut>>();

            var logger = new Mock<ILogger<ForumController>>();
            var forumRepository = new Mock<IForumRepository>();
            forumRepository
                .Setup(f => f.GetForumsByFilterAsync(It.IsAny<ForumFilterDtoIn>()))
                .ReturnsAsync(pagedFilterResult);

            var forumController = new ForumController(
                logger: logger.Object,
                forumRepository: forumRepository.Object
            );
            // Act

            var result = await forumController.FilterBy(apiForumFilterDtoIn);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var responseObject = Assert.IsType<ApiPagedFilterResult<ApiForumDtoOut>>(okObjectResult.Value);
        }
    }
}
