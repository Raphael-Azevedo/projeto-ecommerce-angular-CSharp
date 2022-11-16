using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SanclerAPI.Controllers;
using SanclerAPI.DTO;
using SanclerAPI.Models.Enums;
using SanclerAPI.Services.Interfaces;
using Xunit;

namespace SanclerApiTeste.Controllers
{
    public class InventoryControllerTest
    {
        Mock<IInventoryServices> _InventoryRepositoryMock;
        InventoryController _InventoryController;

        public InventoryControllerTest()
        {
            _InventoryRepositoryMock = new Mock<IInventoryServices>();
            _InventoryController = new InventoryController(_InventoryRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange         
            //Act
            var result = await _InventoryController.Delete(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByProductId_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            //Act
            var result = await _InventoryController.GetByProductId(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Inventory = new CreateInventoryDTO()
            {
                ProductId = 1,
                Size = 1,
                Amount = 1
            };

            //Act

            var result = await _InventoryController.Create(Inventory);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            Size tamanho = Size.S;
            //arrange         
            var Inventory = new UpdateInventoryDTO()
            {
                Size = tamanho,
                Amount = 1
            };

            //Act

            var result = await _InventoryController.Update(1, Inventory);
            //Assert
            Assert.IsType<AcceptedResult>(result);
        }
    }
}