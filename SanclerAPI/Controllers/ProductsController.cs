using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using SanclerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SanclerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {     
            _productServices = productServices; 
        }

        #region "gets"
        /// <summary>
        /// Get all products registered. 
        /// In route specify the pagination of request
        /// the first paramater is the skip, skip is responsable to skip the pages of the response
        /// the second is the take, take is responsabel to set the size of the response
        /// Method: GET
        /// Permission: ALL.
        /// </summary>
        /// <returns>
        /// Json: List of Products
        /// </returns>
        [HttpGet("{skip:int?}/{take:int?}")]
        public async Task<IActionResult> Get([FromRoute] int skip = 0,
                                             [FromRoute] int take = 10)
        {
            try 
            {
                var products = await _productServices.Get(skip, take);
                return Ok(products);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Get one product by id selected.
        /// Method: GET
        /// Permission: All
        /// </summary>
        /// <param name="id"> The id of product </param>
        /// <returns> 
        /// Return one Product in Json
        /// </returns>
        [HttpGet("Product/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productServices.GetById(id);
                return Ok(product);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
            
        }

        #endregion
        /// <summary>
        /// Create a new product in Database
        /// Method: POST
        /// Permission: Admin.
        /// </summary>
        /// <param name="productDTO"> Data Transfer Object of product</param>
        /// <returns> returns 201 if success and 400 to failed </returns>
        [HttpPost]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO productDTO)
        {
            
            try
            {
                await _productServices.Create(productDTO);
                return Created("Created", productDTO);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Update a product in database
        /// Pass the DTO of product with new informations of the product, and in the URL pass the id of the product you want to change
        /// Method: PUT
        /// Permission: Admin
        /// </summary>
        /// <param name="id"> Id of product that you be change</param>
        /// <param name="productDTO">The body of the request with the new informations: 
        /// TITLE
        /// DESCRIPTION
        /// PRICE 
        /// </param>
        /// <returns>return 202 if the accepted request and 304 to not modified</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDTO productDTO)
        {
            try
            {
                await _productServices.Update(id, productDTO);
                return Accepted("Accepted");
            }
            catch (Exception)
            {
                return BadRequest("No Modified!");
            }
        }

        /// <summary>
        /// Boolean Delete of the product, this delete not discard the product from your database,
        /// only change the status and not return in the get requests.
        /// For use this, only pass the id of the product that you want delete, an use the DELETE method
        /// Permission: Admin
        /// </summary>
        /// <param name="id">Id of product that you be delete</param>
        /// <returns>return 200 to success and 400 to fail</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productServices.Delete(id);
                return Ok("The product has be deleted!");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}