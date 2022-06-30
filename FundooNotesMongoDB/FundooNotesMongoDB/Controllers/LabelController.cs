using BussinessLayer.Interface;
using DataBaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooNotesMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL manager;


        public LabelController(ILabelBL manager)
        {
            this.manager = manager;
        }
       // [Authorize]
        [HttpPost]
        [Route("addLabel")]
        public async Task<IActionResult> AddLabel([FromBody] LabelModel label)
        {
            try
            {
                var resp = await this.manager.AddLabel(label);
                if (resp != null)
                {
                    return this.Ok(new ResponseModel<LabelModel> { Status = true, Message = "Label Added Successfully", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = "Record Note " });
                }
            }
            catch (Exception e)
            {
                {
                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        //[Authorize]
        [HttpDelete]
        [Route("deleteLabel")]
        public async Task<IActionResult> DeleteLabel(LabelModel label)
        {
            try
            {

                bool resp = await this.manager.DeleteLabel(label);
                if (resp != false)
                {

                    return this.Ok(new ResponseModel<LabelModel> { Status = true, Message = "Label Delete Successfully!!!!!!!!!!! ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = "Label Not Found!!!!!!!" });
                }
            }
            catch (Exception e)
            {
                {
                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }

        }
        [HttpGet]
        [Route("getallLabel")]
        public IEnumerable<LabelModel> GetAllLabels()
        {
            try
            {
                var resp = this.manager.GetAllLabels();
                return resp;
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
