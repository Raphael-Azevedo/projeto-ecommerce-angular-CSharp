using Xunit;
using Moq;
using SanclerAPI.Services.Interfaces;
using SanclerAPI.Controllers;
using SanclerAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.DTO;

namespace SanclerApiTeste
{
    public class ProductsControllerTest
    {
        Mock<IProductServices> _productRepositoryMock;
        ProductsController _productsController;

        public ProductsControllerTest()
        {
            _productRepositoryMock = new Mock<IProductServices>();
            _productsController = new ProductsController(_productRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange         
            //Act
            var result = await _productsController.Delete(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _productsController.Get(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange         
            //Act
            var result = await _productsController.GetById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var product = new CreateProductDTO()
            {
                Title = "teste",
                Descriptions = "teste",
                Price = 1.2M,
                SKU = "teste"
            };

            //Act

            var result = await _productsController.Create(product);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var product = new UpdateProductDTO()
            {
                Title = "teste",
                Descriptions = "teste",
                Price = 1.2M
            };

            //Act

            var result = await _productsController.Update(1,product);
            //Assert
            Assert.IsType<AcceptedResult>(result);
        }
    }
}
