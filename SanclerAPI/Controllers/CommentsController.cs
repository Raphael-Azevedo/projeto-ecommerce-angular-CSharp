using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.Repository.Interfaces;
using System;
using SanclerAPI.DTO;
using System.Linq;
using AutoMapper;
using SanclerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SanclerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentsController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        #region "gets"
        /// <summary>
        /// Get one comment by your Id
        /// Method: GET
        /// Permission: All
        /// </summary>
        /// <param name="id"> Id of the comment</param>
        /// <returns>return one comment in JSON format</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var comment = await _commentServices.GetById(id);
                return Ok(comment);
            }
            catch (Exception)
            {
               return BadRequest("Invalid Request");
            }

        }
        /// <summary>
        /// Returns comments maked for one user that be logger
        /// Method: GET
        /// Permission: Only Logger user
        /// </summary>
        /// <returns>A list of comments</returns>
        [HttpGet("GetByUserId/{skip:int?}/{take:int?}")]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetByUserId([FromRoute] int skip = 0,
                                                        [FromRoute] int take = 10)
        {
            try
            {
                var Comments = await _commentServices.GetByUserId(skip, take, User);
                if (Comments.Count() == 0)
                {
                    return NotFound("No content!");
                }
                return Ok(Comments);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
        /// <summary>
        /// Returns Comments per Product Id
        /// the comments belong a determinated product
        /// Method: GET
        /// Permission: AlL
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns>A list of comments</returns>
        [HttpGet("GetByProductId/{id}/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetByProductId(int id,
                                            [FromRoute] int skip = 0,
                                            [FromRoute] int take = 10)
        {
            try
            {
                var Comments = await _commentServices.GetByProductId(id, skip, take);
                if (Comments.Count() == 0)
                {
                    return NotFound("No content!");
                }
                return Ok(Comments);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        #endregion
        /// <summary>
        /// Create a new comment in Database
        /// Pass in the body the comment and the product ID to create a new comment
        /// Method: POST
        /// Permission: Loggers Users
        /// </summary>
        /// <param name="CommentDto"> The body of the request that contains informations to new comment</param>
        /// <returns>201 if success and 400 to fail</returns>
        [HttpPost]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] CreateCommentDTO CommentDto)
        {
            try
            {
                await _commentServices.Create(CommentDto, User);
                return Created("Created", CommentDto);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Update a comment in database
        /// Pass de id in the URL and the body of the request with new informations.
        /// Method: PUT
        /// </summary>
        /// <param name="id">The id of the comment if you want delete</param>
        /// <param name="commentDto">The body of the request, the informations if you want update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentDTO commentDto)
        {
            try
            {
                await _commentServices.Update(id, commentDto, User);
                return Accepted("Accepted");
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest("Not modified!");
            }
        }
        /// <summary>
        /// Delete one comment of the database
        /// *** WARNING ** 
        /// if you delete, the comment is not possible to be recupered
        /// Method: DELETE
        /// Permission: Admin
        /// </summary>
        /// <param name="id">Id of the comment a be deleted</param>
        /// <returns>200 to Ok and 400 to fail</returns>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _commentServices.Delete(id, User);
                return Ok("The comment has been deleted!");
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}