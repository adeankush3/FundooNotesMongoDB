using BussinessLayer.Interface;
using DataBaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooNotesMongoDB.Controllers
{
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorsBL manager;
        public CollaboratorsController(ICollaboratorsBL manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("addCollaborators")]
        public async Task<IActionResult> AddCollaborators([FromBody] CollaboratorsModel Collaborators)
        {
            try
            {
                var resp = await this.manager.AddCollaborators(Collaborators);
                if (resp != null)
                {
                    return this.Ok(new ResponseModel<CollaboratorsModel> { Status = true, Message = "Collaborators Added Successfully!!!!", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = "Record Note !!!!!!" });
                }
            }
            catch (Exception e)
            {
                {
                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [HttpDelete]
        [Route("removeCollaborators")]
        public async Task<IActionResult> RemoveCollaborators(CollaboratorsModel collaborators)
        {
            try
            {

                bool resp = await this.manager.RemoveCollaborators(collaborators);
                if (resp != false)
                {

                    return this.Ok(new ResponseModel<CollaboratorsModel> { Status = true, Message = "Remove Collaborators!!!!!!!!!!! ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = "Collaborators Not Found!!!!!!!" });
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
        [Route("getallCollaborators")]
        public IEnumerable<CollaboratorsModel> GetAllCollaborators()
        {
            try
            {
                var resp = this.manager.GetAllCollaborators();
                return resp;
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
