using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.DTO;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssessmentController : Controller
    {    
        private readonly IAssessmentServices _assessmentServices;

        public AssessmentController(IAssessmentServices assessmentServices)
        {
            _assessmentServices = assessmentServices;
        }

        #region "gets"
        /// <summary>
        /// Get one assessment by your Id
        /// Method: GET
        /// Permission: All
        /// </summary>
        /// <param name="id"> Id of the assessment</param>
        /// <returns>return one assessment in JSON format</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Assesment = await _assessmentServices.GetById(id);
                return Ok(Assesment);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
            
        }
        /// <summary>
        /// Returns assessment maked for one user that be logger
        /// Method: GET
        /// Permission: Only Logger user
        /// </summary>
        /// <returns>A list of assessments</returns>
        [HttpGet("GetByUserId/{skip:int?}/{take:int?}")]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetByUserId([FromRoute]int skip = 0, 
                                                     [FromRoute]int take = 10)
        {
            try
            {
                var Assessments = await _assessmentServices.GetByUserId(skip, take, User);
                if (Assessments.Count() == 0)
                {
                    return NotFound("No content!");
                }
                return Ok(Assessments);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
            
        }

        /// <summary>
        /// Returns assessments per Product Id
        /// the assessments belong a determinated product
        /// Method: GET
        /// Permission: AlL
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns>A list of assessments</returns>
        [HttpGet("GetByProductId/{id}/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetByProductId(int id, 
                                                        [FromRoute]int skip = 0, 
                                                        [FromRoute]int take = 10)
        {
            try
            {
                var Assessments = await _assessmentServices.GetByProductId(id, skip, take);    
                if (Assessments.Count() == 0)
                {
                    return NotFound("No content!");
                }
                return Ok(Assessments);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }  
        }
        #endregion
        /// <summary>
        /// Create a new assessments in Database
        /// Pass in the body the assessments and the product ID to create a new assessments
        /// Method: POST
        /// Permission: Loggers Users
        /// </summary>
        /// <param name="assessmentDto"> The body of the request that contains informations to new assessments</param>
        /// <returns>201 if success and 400 to fail</returns>
        [HttpPost]
        [Authorize(Roles = "admin, regular" , AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] CreateAssessmentDTO assessmentDto)
        {
            try
            {
                await _assessmentServices.Create(assessmentDto, User);
                return Created("Created",assessmentDto);
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }          
        }

        /// <summary>
        /// Delete one assessment of the database
        /// *** WARNING ** 
        /// if you delete, the assessment is not possible to be recupered
        /// Method: DELETE
        /// Permission: Admin
        /// </summary>
        /// <param name="id">Id of the assessment a be deleted</param>
        /// <returns>200 to Ok and 400 to fail</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _assessmentServices.Delete(id, User);
                return Ok("your review has been deleted!");
            }
            catch (InvalidOperationException)
            {
                return Unauthorized("Unauthorized");
            }
            catch(Exception)
            {
                return BadRequest("Invalid Request");
            }
            
        }
        /// <summary>
        /// Update a assessment in database
        /// Pass de id in the URL and the body of the request with new informations.
        /// Method: PUT
        /// </summary>
        /// <param name="id">The id of the assessment if you want delete</param>
        /// <param name="assessmentsDto">The body of the request, the informations if you want update</param>
        /// <returns>202 to sucecs and 400 or 401 to fail</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin, regular", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAssessmentsDTO assessmentsDto)
        {
            try
            {
                await _assessmentServices.Update(id, assessmentsDto, User);
                return Accepted("Accepted");
            }
            catch (InvalidOperationException)
            {
                return Unauthorized("Unauthorized");
            }
            catch(Exception)
            {
                return BadRequest("Not modified");
            }     
        }

    }
}