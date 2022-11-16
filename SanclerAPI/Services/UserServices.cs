using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SanclerAPI.Data;
using SanclerAPI.DTO;
using SanclerAPI.Models;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class UserServices :IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailServices _emailServices;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserServices(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IMapper mapper,
                            IConfiguration configuration,
                            IEmailServices emailServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _emailServices = emailServices;
        }

        public async Task<Result> LogIn(LoginUserDTO userInfo)
        {
           var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);

            if(result.Succeeded)
            {
                var identityUser = GetUserPerEmail(userInfo.Email);
                return Result.Ok().WithSuccess(GeraToken(userInfo, _signInManager
                                                                    .UserManager
                                                                    .GetRolesAsync(identityUser).Result.FirstOrDefault()).Token);;
            }
            else return Result.Fail("Fail to login user");
        }

        public Result Logout()
        {
            var result =_signInManager.SignOutAsync();
            if(result.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Fail logout");
        }
        
        public async Task<Result> RegisterUser(RegisterUserDTO model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            var userRoleResult = _userManager.AddToRoleAsync(user, "regular").Result;

            if (!result.Succeeded)
            {
                return Result.Fail("Fail to register a user! ");
            }
            else
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var model_login = _mapper.Map<LoginUserDTO>(model);

                var encodedCode = HttpUtility.UrlEncode(code);
                Message message = new Message(new [] { user.Email }, "Activation Link", user.Id, encodedCode);
                _emailServices.SendEmail(message);

                return Result.Ok().WithSuccess($"Email Code: {code}");
            }
        }

        public Result MakeResetPassword(MakeResetRequest request)
        {
            IdentityUser identityUser = GetUserPerEmail(request.Email);

            IdentityResult resultIdentity = _signInManager
                    .UserManager
                    .ResetPasswordAsync(identityUser, request.Token, request.Password)
                    .Result;

            if (resultIdentity.Succeeded) return Result.Ok().WithSuccess("Password reseted with success");
            return Result.Fail("Fail request");
        }

        private IdentityUser GetUserPerEmail(string Email)
        {
            return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(u => u.NormalizedEmail == Email.ToUpper());
        }

        public Result RequestResetPassword(RequestReset request)
        {
            
            IdentityUser identityUser = GetUserPerEmail(request.Email);
            if(identityUser != null)
            {
                string ResetCode = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                var encodedCode = HttpUtility.UrlEncode(ResetCode);

                string confirmationCode = encodedCode.Substring((encodedCode.Length - 5), 5);
                string queryString = encodedCode.Substring(0, (encodedCode.Length - 5));

                string emailContent = @$"
                    You reset code : {confirmationCode}
                    Access the link in postman and send :
                    [
                        Password: *****,
                        RePassword: *****,
                        Email: ****,
                        Token: ****, 
                    ]

                    https://localhost:5001/api/v1/Autorization/make-reset?T={queryString}          
                    
                ";

                Message msg = new Message(new [] {identityUser.Email} , "Reset password code! ", emailContent);
                _emailServices.SendEmail(msg);
                return Result.Ok().WithSuccess("The password has be changed!");
            }
            return Result.Fail("Fail to request reset password.");
        }

        

        private UserTokenDTO GeraToken(LoginUserDTO userInfo, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims:claims,
                expires: expiration,
                signingCredentials: credenciais
            );

            return new UserTokenDTO()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT Ok"
            };
        }
    }
}