﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
using Newtonsoft.Json;
using Server.DTO;

namespace Server.Controllers
{
    [Route("api/seminar")]
    public class SeminarController : Controller
    {
        private ISeminarService seminarService;
        public SeminarController(ISeminarService _seminarService)
        {
            seminarService = _seminarService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(seminarService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAll2")]
        public IActionResult FindAll2()
        {
            try
            {
                return Ok(seminarService.FindAll2());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAll3/{idPerson}")]
        public IActionResult FindAll3(string idPerson)
        {
            try
            {
                return Ok(seminarService.FindAll3(idPerson));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findRecent/{n}")]
        public IActionResult findRecent(int n)
        {
            try
            {
                return Ok(seminarService.RecentSeminar(n));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findDTO/{idSeminar}")]
        public IActionResult FindDTO(int idSeminar)
        {
            try
            {
                return Ok(seminarService.FindDTO(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idSeminar}")]
        public IActionResult Find(int idSeminar)
        {
            try
            {
                return Ok(seminarService.Find(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] SeminarDTO seminarDTO)
        {
            try
            {
                var seminar = new Seminar
                {
                    Id = 0,
                    Img = seminarDTO.Img,
                    Name = seminarDTO.Name,
                    Presenters = seminarDTO.Presenters,
                    TimeStart = TimeSpan.Parse(seminarDTO.TimeStart),
                    TimeEnd = TimeSpan.Parse(seminarDTO.TimeEnd),
                    Day = seminarDTO.Day,
                    Place = seminarDTO.Place,
                    Maximum = seminarDTO.Maximum,
                    Descriptoin = seminarDTO.Descriptoin,
                    Active = seminarDTO.Active,
                    Status = true
                };
                return Ok(seminarService.Create(seminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] SeminarDTO seminarDTO)
        {
            try
            {
                return Ok(seminarService.Update(seminarDTO));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("UpdatePre/{idSeminar}/{idPrecenter}")]
        public IActionResult UpdatePre(int idSeminar, string idPrecenter)
        {
            try
            {
                return Ok(seminarService.UpdatePre(idSeminar, idPrecenter));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("delPer/{idSeminar}/{idPerforment}")]
        public IActionResult DelPerforment(int idSeminar, int idPerforment)
        {
            try
            {
                return Ok(seminarService.DelPerforment(idSeminar, idPerforment));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpDelete("Del/{idSeminar}")]
        public IActionResult Del(int idSeminar)
        {
            try
            {
                return Ok(seminarService.Del(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addperforment")]
        public IActionResult AddPerforment([FromBody] PerformenSeminar performenSeminar)
        {
            try
            {
                return Ok(seminarService.AddPerforment(performenSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("countAccept")]
        public IActionResult CountAccpet()
        {
            try
            {
                return Ok(seminarService.CountAccept() + " ");
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("listAccept")]
        public IActionResult ListAccpet()
        {
            try
            {
                return Ok(seminarService.ListAccept());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("accept/{idSeminar}")]
        public IActionResult Accpet(int idSeminar)
        {
            try
            {
                return Ok(seminarService.Accept(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpDelete("delAccept/{idSeminar}")]
        public IActionResult DelAccpet(int idSeminar)
        {
            try
            {
                return Ok(seminarService.DelAccept(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("updatenum/{id}")]
        public IActionResult UpdateNum(int id)
        {
            try
            {
                return Ok(seminarService.UpdateNumber(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("checkmaximum")]
        public IActionResult CheckMaximum()
        {
            try
            {
                return Ok(seminarService.CheckMaximum());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("register/{id}")]
        public IActionResult RegisteredSeminar(int id)
        {
            try
            {
                return Ok(seminarService.RegisteredSeminar(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("checkdateseminar")]
        public IActionResult CheckDateSeminar()
        {
            try
            {
                return Ok(seminarService.CheckDateSeminar());
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
