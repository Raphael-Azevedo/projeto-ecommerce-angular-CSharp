using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SanclerAPI.Controllers;
using SanclerAPI.DTO;
using SanclerAPI.Services.Interfaces;
using Xunit;

namespace SanclerApiTeste.Controllers
{
    public class CommentsControllerTest
    {
        Mock<ICommentServices> _CommentsRepositoryMock;
        CommentsController _CommentsController;

        public CommentsControllerTest()
        {
            _CommentsRepositoryMock = new Mock<ICommentServices>();
            _CommentsController = new CommentsController(_CommentsRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange         
            //Act
            var result = await _CommentsController.Delete(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByProductId_ReturnsANotFoundObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _CommentsController.GetByProductId(1);
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetByUserId_ReturnsANotFoundObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _CommentsController.GetByUserId();
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange         
            //Act
            var result = await _CommentsController.GetById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Comments = new CreateCommentDTO()
            {
                ProductId = 1,
                Comment = "teste"
            };

            //Act

            var result = await _CommentsController.Create(Comments);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Comments = new UpdateCommentDTO()
            {
                Comment = "teste"
            };

            //Act

            var result = await _CommentsController.Update(1, Comments);
            //Assert
            Assert.IsType<AcceptedResult>(result);
        }
    }
}