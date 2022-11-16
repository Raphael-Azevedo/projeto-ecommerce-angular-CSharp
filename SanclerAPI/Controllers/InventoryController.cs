using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.DTO;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _inventoryServices;


        public InventoryController(IInventoryServices inventoryServices)
        {
            _inventoryServices = inventoryServices;
        }

        /// <summary>
        /// Return one stock the deterninated product, for use this method pass the id of the product in URL of the request. 
        /// Method: Get
        /// Permission: Admin
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns> One list of the inventorys</returns>
        [HttpGet("GetByProductId/{id}")]
        public async Task<IActionResult> GetByProductId(int id)
        {
            try
            {
                var inventorys = await _inventoryServices.GetByProductId(id);
                return Ok(inventorys);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }  
            
        }

        /// <summary>
        /// Create a new Inventory in the DataBase
        /// Method: Post
        /// Permissions: Admin
        /// </summary>
        /// <param name="inventoryDto">Body of the request, contains a informations to the new inventory a be register</param>
        /// <returns>201 to created and 400 to fail</returns>
        [HttpPost]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] CreateInventoryDTO inventoryDto)
        {
            try
            {
                await _inventoryServices.Create(inventoryDto);
                return Created("Created", inventoryDto);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Update one inventory of the database
        /// To use this method you need pass the id in the URL and one json that contains the new informations.
        /// Method: PUT
        /// Permission: Admin
        /// </summary>
        /// <param name="id"> Id of the inventory a be Updated</param>
        /// <param name="inventoryDto">Body of the request, contains a informations to the new inventory a be updated</param>
        /// <returns>202 to acccepted and 304 to fail</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInventoryDTO inventoryDto)
        {
            try
            {
                await _inventoryServices.Update(id, inventoryDto);
                return Accepted("Accepted");
            }
            catch(Exception)
            {
                return BadRequest("Not Modified!");
            }    
        }
        /// <summary>
        /// Delete one inventory of the database
        /// *** WARNING ** 
        /// if you delete, the inventory is not possible to be recupered
        /// Method: DELETE
        /// Permission: Admin
        /// </summary>
        /// <param name="id"> Id of the inventory a be deleted</param>
        /// <returns>200 to Ok and 400 to fail</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                await _inventoryServices.Delete(id); 
                return Ok("The comment has be deleted!");
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
    }
}