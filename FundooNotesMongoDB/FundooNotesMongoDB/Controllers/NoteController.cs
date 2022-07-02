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
    public class NoteController : ControllerBase
    {
        private readonly INoteBL manager;


        public NoteController(INoteBL manager)
        {
            this.manager = manager;
        }

        //[Authorize]
        [HttpPost]
        [Route("addNote")]
        public async Task<IActionResult> AddNote([FromBody] NoteModel note)
        {
            try
            {
                var resp = await this.manager.AddNote(note);
                if (resp != null)
                {
                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = "Note Added Successfully", Data = resp });
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
        [Authorize]
        [HttpPut]
        [Route("upadatenote")]
        public async Task<IActionResult> UpdateNote([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.UpdateNote(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = " Note Record Update Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("deleteNote")]
        public async Task<IActionResult> DeleteNote(NoteModel note)
        {
            try
            {

                bool resp = await this.manager.DeleteNote(note);
                if (resp != false)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = "Note Delete Successfully!!!!!!!!!!! ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = "Note Not Found!!!!!!!" });
                }
            }
            catch (Exception e)
            {
                {
                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }

        }
        [Authorize]
        [HttpGet]
        [Route("getallNotes")]
        public IEnumerable<NoteModel> GetAllNotes()
        {
            try
            {
                var resp = this.manager.GetAllNotes();
                return resp;
            }

            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("ChangeColour")]
        public async Task<IActionResult> ChangeColour([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.ChangeColour(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = " Change Colour Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [Authorize]
        [HttpPut]
        [Route("ArchiveNote")]
        public async Task<IActionResult> ArchiveNote([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.ArchiveNote(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = " Archive Note Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [Authorize]
        [HttpPut]
        [Route("PinNotes")]
        public async Task<IActionResult> Pin([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.Pin(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = " Pin Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [Authorize]
        [HttpPut]
        [Route("TrashNote")]
        public async Task<IActionResult> Trash([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.Trash(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = " Trash Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }
        [Authorize]
        [HttpPut]
        [Route("setRemainder")]
        public async Task<IActionResult> Remainder([FromBody] NoteModel note)
        {
            try
            {

                var resp = await this.manager.Remainder(note);
                if (resp != null)
                {

                    return this.Ok(new ResponseModel<NoteModel> { Status = true, Message = "Set Remainder Succeessfully ", Data = resp });
                }
                else
                {

                    return this.BadRequest(new { Status = false, Message = " Record not Update" });
                }
            }
            catch (Exception e)
            {
                {

                    return this.NotFound(new { Status = false, Message = e.Message });
                }
            }
        }

    }
}
