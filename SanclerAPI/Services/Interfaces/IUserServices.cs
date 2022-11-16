using System.Threading.Tasks;
using FluentResults;
using SanclerAPI.Data;
using SanclerAPI.DTO;

namespace SanclerAPI.Services.Interfaces
{
    public interface IUserServices
    {
        Task<Result> RegisterUser(RegisterUserDTO model);
        Result Logout();
        Task<Result> LogIn(LoginUserDTO userInfo);
        Result RequestResetPassword(RequestReset request);
        Result MakeResetPassword(MakeResetRequest request);
    }
}