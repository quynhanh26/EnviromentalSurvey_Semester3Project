using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/registerseminar")]
    public class RegisterSeminarController : Controller
    {
        private IRegisterSeminarService registerSeminarService;
        public RegisterSeminarController(IRegisterSeminarService _registerSeminarService)
        {
            registerSeminarService = _registerSeminarService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(registerSeminarService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] RegisterSeminar registerSeminar)
        {
            try
            {
                return Ok(registerSeminarService.Create(registerSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("checkexists/{idrs}/{idacc}")]
        public IActionResult Checkexists(int idrs, int idacc)
        {
            try
            {
                return Ok(registerSeminarService.CheckExists(idrs, idacc));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idregister}")]
        public IActionResult Find(int id)
        {
            try
            {
                return Ok(registerSeminarService.Find(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findid/{idseminar}")]
        public IActionResult FindIdSeminar(int idseminar)
        {
            try
            {
                return Ok(registerSeminarService.Find(idseminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("addseminar/{id}")]
        public IActionResult AddSeminar(int id)
        {
            try
            {
                return Ok(registerSeminarService.AddSeminar(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
