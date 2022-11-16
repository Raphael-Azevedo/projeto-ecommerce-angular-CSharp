using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SanclerAPI.Controllers;
using SanclerAPI.DTO;
using SanclerAPI.Models;
using SanclerAPI.Services.Interfaces;
using Xunit;

namespace SanclerApiTeste.Controllers
{
    public class AssessmentControllerTest
    {
        Mock<IAssessmentServices> _assessmentRepositoryMock;
        AssessmentController _AssessmentController;

        public AssessmentControllerTest()
        {
            _assessmentRepositoryMock = new Mock<IAssessmentServices>();
            _AssessmentController = new AssessmentController(_assessmentRepositoryMock.Object);
            var product = new Product()
            {
                Id = 1,
                Title = "teste",
                Descriptions = "teste",
                SKU = "teste",
                Status = true,
                Price = 1.2M
            };
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange         
            //Act
            var result = await _AssessmentController.Delete(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByProductId_ReturnsANotFoundObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _AssessmentController.GetByProductId(1);
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
                [Fact]
        public async Task GetByUserId_ReturnsANotFoundObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _AssessmentController.GetByUserId();
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange         
            //Act
            var result = await _AssessmentController.GetById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var assessment = new CreateAssessmentDTO()
            {
                ProductId = 1,
                Evaluation = 1
            };

            //Act

            var result = await _AssessmentController.Create(assessment);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var assessment = new UpdateAssessmentsDTO()
            {
                Evaluation = 1
            };

            //Act

            var result = await _AssessmentController.Update(1, assessment);
            //Assert
            Assert.IsType<AcceptedResult>(result);
        }
    }
}