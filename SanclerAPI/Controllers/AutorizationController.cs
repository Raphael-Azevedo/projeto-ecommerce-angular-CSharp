using System;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SanclerAPI.Data;
using SanclerAPI.DTO;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutorizationController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IEmailServices _emailServices;

        public AutorizationController(IUserServices userServices,
                                      IEmailServices emailServices)
        {
            _userServices = userServices;
            _emailServices = emailServices;
        }
        /// <summary>
        /// Informations about login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AutorizationController :: Access in : " + DateTime.Now.ToLongDateString();
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            Result result = await _userServices.RegisterUser(model);
            if(result.IsFailed) return BadRequest();
            return Ok(result.Successes);
            
        }
        /// <summary>
        /// Login in a user
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>Token</returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO userInfo)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }
            var result = await _userServices.LogIn(userInfo);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
            
        }
        /// <summary>
        /// Confirm your account, used with query string sended in your email.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("Confirm")]
        public async Task<IActionResult> ComfirmAccount([FromQuery] ConfirmEmailRequest request)
        {
            var result = await _emailServices.ConfirmAccount(request);
            if (result.IsSuccess) return Ok("your account have be a confirmed!");
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Logout user!
        /// </summary>
        /// <returns></returns>
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Result result = _userServices.Logout();
            if(result.IsSuccess) return Ok(result);
            return Unauthorized("Log out fail!");
        }
        /// <summary>
        /// Send a email with a request to reset your password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("request-reset")]
        public IActionResult RequestReset(RequestReset request)
        {
            Result result = _userServices.RequestResetPassword(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
        /// <summary>
        /// Validate request to change password
        /// </summary>
        /// <param name="T"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("make-reset")]
        public IActionResult MakeResetPassword([FromQuery] string T,
                                               [FromBody] MakeResetRequest request)
        {
            var Token = T + request.Token;
            request.Token = Token;
            Result result = _userServices.MakeResetPassword(request);
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }

    }
}
