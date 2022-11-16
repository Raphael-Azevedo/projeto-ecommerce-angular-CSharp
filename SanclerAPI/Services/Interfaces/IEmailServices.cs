using System.Threading.Tasks;
using FluentResults;
using SanclerAPI.Data;
using SanclerAPI.Models;

namespace SanclerAPI.Services.Interfaces
{
    public interface IEmailServices
    {
        Task<Result> ConfirmAccount(ConfirmEmailRequest request);
        void SendEmail(Message msg);
        
    }
}