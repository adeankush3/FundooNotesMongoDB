using BussinessLayer.Interface;
using DataBaseLayer;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Bussiness
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository repo;
        public UserBL(IUserRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Forgot(string emailID)
        {
            try
            {
                return await this.repo.Forgot(emailID);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string GetJWTToken(string emailID)
        {
            if (emailID == null)
            {
                return null;
            }

            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("emailID", emailID),

                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials =
                               new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserModel> Login(LoginModel login)
        {
            try
            {
                return await this.repo.Login(login);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<UserModel> Register(UserModel register)
        {

            try
            {
                return await this.repo.Register(register);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<UserModel> Reset(ResetModel reset)
        {
            try
            {
                return await this.repo.Reset(reset);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
