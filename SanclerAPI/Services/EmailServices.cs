using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SanclerAPI.Data;
using SanclerAPI.Models;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public EmailServices(UserManager<IdentityUser> userManager,
                             SignInManager<IdentityUser> signInManager,
                             IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<Result> ConfirmAccount(ConfirmEmailRequest request)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == request.UserId);
            var result = await _userManager.ConfirmEmailAsync(user, request.AcctivationCode);
            if (result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Fail to confirm yout account");
        }

        public void SendEmail(Message message)
        {
            var EmailMesage = CreateEmailBody(message);
            Send(EmailMesage);
        }

        private void Send(MimeMessage emailMesage)
        {
                      
           using(SmtpClient client = new SmtpClient())
           {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect( _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                                    _configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.Auto);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate( _configuration.GetValue<string>("EmailSettings:From"),
                                         _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(emailMesage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
           }
        }

        private MimeMessage CreateEmailBody(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Admin", _configuration.GetValue<string>("EmailSettings:From")));
            emailMessage.To.AddRange(message.Addresse);
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = message.Content};

            return emailMessage;
        }
    }
}