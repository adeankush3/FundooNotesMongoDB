using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> Register(UserModel register);
        Task<UserModel> Login(LoginModel login);
        Task<UserModel> Reset(ResetModel reset);
        Task<bool> Forgot(string emailID);
    }
}
