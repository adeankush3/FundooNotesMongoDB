using BussinessLayer.Interface;
using DataBaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooNotesMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL manager;
        public UserController(IUserBL manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("addUser")]

        public async Task<IActionResult> Register([FromBody] UserModel register)
        {
            try
            {
                var resp = await this.manager.Register(register);
                if (resp != null)
                {
                    return this.Ok(new ResponseModel<UserModel> { Status = true, Message = "User Register Successfully", Data = resp });
                }
                else
                {
                   
                    return this.BadRequest(new { Status = false, Message = "User Not Register" });
                }
            }
            catch (Exception e)
            {
                {
                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }

        //Login Part
        //[Authorize]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
               
                var response = await this.manager.Login(login);
                if (response != null)
                {
                    string token = this.manager.GetJWTToken(login.emailID);
                    return this.Ok(new ResponseModel<UserModel> { Status = true, Message = "User Login Successfully", Token = token });
                }
                else

                {
                   
                    return this.BadRequest(new { Status = false, Message = "InCorrect UserName or Password" });
                }

            }
            catch (Exception e)
            {
               
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        //[Authorize]
        [HttpPut]
        [Route("reset")]
        public async Task<IActionResult> Reset(ResetModel reset)
        {
            try
            {
                 //string emailID = User.FindFirst(ClaimTypes.Email).Value.ToString();
                //var emailID = User.Claims.FirstOrDefault(e => e.Type == "Email").Value.ToString();
                var response = await this.manager.Reset(reset);
                if (response != null)
                {
                    return this.Ok(new ResponseModel<UserModel> { Status = true, Message = "Password Change Successfully", Data = response });

                }
                else

                {
                    return this.BadRequest(new { Status = false, Message = "Reset Password Failed", Data = response });

                }

            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        //[Authorize]
        [HttpPost]
        [Route("forgot")]
        public async Task<IActionResult> Forgot(string emailID)
        {
            try
            {
                bool response = await this.manager.Forgot(emailID);
                if (response != false)
                {
                    string token = this.manager.GetJWTToken(emailID);
                    return this.Ok(new ResponseModel<UserModel> { Status = true, Message = "Mail Send Successfully", Token = token });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Mail Not Send" });

                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        
    }
}
