using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface IUserBL
    {
        Task<UserModel> Register(UserModel register);
        Task<UserModel> Login(LoginModel login);
        public string GetJWTToken(string emailID);
        Task<UserModel> Reset(ResetModel reset);
        Task<bool> Forgot(string emailID);
    }
}
