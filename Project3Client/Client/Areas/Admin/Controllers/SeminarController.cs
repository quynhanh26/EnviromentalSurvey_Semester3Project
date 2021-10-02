using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using System.Net.Http.Json;
using System.Diagnostics;
using Newtonsoft.Json;
using Client.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Client.DTO;
using Client.Helpers;

namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/seminar")]
    public class SeminarController : Controller
    {
        private ISeminarAPI seminarAPI;
        private IWebHostEnvironment webHostEnvironment;
        private IAllPeopleAPI allPeopleAPI;
        private IPerformerAPI performerAPI;
        private IImgAPI imgAPI;
        public SeminarController(ISeminarAPI _seminarAPI, IWebHostEnvironment _webHostEnvironment, IAllPeopleAPI _allPeopleAPI, IPerformerAPI _performerAPI, IImgAPI _imgAPI)
        {
            seminarAPI = _seminarAPI;
            allPeopleAPI = _allPeopleAPI;
            performerAPI = _performerAPI;
            webHostEnvironment = _webHostEnvironment;
            imgAPI = _imgAPI;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.listSeminarDTO = seminarAPI.findAll2();
            return View();
        }
        [Route("create")]
        public IActionResult Create()
        {
            ViewBag.listStaff = allPeopleAPI.findStaff();
            return View(new SeminarDTO());
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(SeminarDTO seminarDTO, IFormFile file)
        {
            seminarDTO.Active = true;
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/seminar", fileName);
                seminarDTO.Img = fileName;
                ViewBag.msg = seminarAPI.Create(seminarDTO);
                if (ViewBag.msg == "Seccuss")
                {
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return Redirect("/admin/seminar/index");
                }
            }
            else
            {
                seminarDTO.Img = "seminarDefault.png";
                ViewBag.msg = seminarAPI.Create(seminarDTO);
                if (ViewBag.msg == "Seccuss")
                    return Redirect("/admin/seminar/index");

            }

            return View();
        }

        [Route("del")]
        public IActionResult Del(int idSeminar)
        {
            var listSeminar = seminarAPI.Del(idSeminar);
            return new JsonResult(listSeminar);
        }
        [Route("detail")]
        public IActionResult Details(int idSeminar)
        {
            var seminar = seminarAPI.Find(idSeminar);
            ViewBag.listStaff = allPeopleAPI.findStaff();
            return View(seminar);
        }
        [Route("updatePrecenter")]
        public IActionResult UpdatePre(int idSeminar, string idPrecenter)
        {
            var precenter = seminarAPI.updatePre(idSeminar, idPrecenter).PresentersNavigation;
            return new JsonResult(precenter);
        }
        [Route("update")]
        public IActionResult Update(Seminar seminar, bool status, IFormFile file)
        {

            var seminarDTO = new SeminarDTO
            {
                Id = seminar.Id,
                Img = seminar.Img,
                Name = seminar.Name,
                TimeStart = seminar.TimeStart.ToString(),
                TimeEnd = seminar.TimeEnd.ToString(),
                Day = seminar.Day,
                Place = seminar.Place,
                Maximum = seminar.Maximum,
                Descriptoin = seminar.Descriptoin,
                Status = status
            };
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/seminar", fileName);
                seminarDTO.Img = fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var id = seminarAPI.update(seminarDTO);
            return RedirectToAction("details", new { idSeminar = int.Parse(id) });
        }
        [Route("performent")]
        public IActionResult Performent(int idSeminar)
        {
            ViewBag.performents = seminarAPI.Find(idSeminar).PerformenSeminars;
            ViewBag.idSeminar = idSeminar;
            return View();
        }
        [Route("delPerforment")]
        [HttpPost]
        public IActionResult DelPerforment(int idSeminar, int idPerforment)
        {

            var performents = seminarAPI.delPerforment(idSeminar, idPerforment);

            return new JsonResult(performents);
        }
        [Route("findPer")]
        public IActionResult FindPer(int idSeminar)
        {

            var performents = performerAPI.Find2(idSeminar);
            return new JsonResult(performents);
        }
        [Route("addPerforment")]
        public IActionResult AddPerforment(int idSeminar, int idPerforment)
        {
            var perSemi = new PerformenSeminar
            {
                IdSeminar = idSeminar,
                IdPerforment = idPerforment,
                Status = true
            };

            var performents = seminarAPI.AddPerforment(perSemi).PerformenSeminars;
            return new JsonResult(performents);
        }
        [Route("image")]
        public IActionResult Image(int idSeminar)
        {
            ViewBag.listImg = imgAPI.GetImgSer(idSeminar);
            ViewBag.idSeminar = idSeminar;
            return View();
        }
        [Route("delImg")]
        public IActionResult delImg(int idSeminar, int idImg)
        {
            imgAPI.DelImgSer(idSeminar, idImg);
            return RedirectToAction("Image", new { idSeminar = idSeminar });
        }
        [Route("addImgSer")]
        public IActionResult AddImgSer(int idSeminar, IFormFile file)
        {

            var ext = file.ContentType.Split(new char[] { '/' })[1];
            var fileName = RandomHelper.RandomString(8) + "." + ext;
            var path = Path.Combine(webHostEnvironment.WebRootPath, "img/seminar", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var img = new Img { Id = 0, Path = fileName, IdSeminar = idSeminar };
            imgAPI.AddImgSer(img);
            try
            {
                return RedirectToAction("Image", new { idSeminar = idSeminar });
            }catch(Exception e)
            {
                var a = e.Message;
            }
            return View();
        }
        [Route("listSerActive")]
        public IActionResult ListSerActive()
        {
            ViewBag.listSeminar = seminarAPI.ListAccept();
            return View();
        }

        [Route("detailSerAccept")]
        public IActionResult DetailSerAccept(int id)
        {
            return View(seminarAPI.Find(id));
        }
        [Route("accept")]
        public IActionResult Accept(int id)
        {
            seminarAPI.Accept(id);
            return RedirectToAction("listSerActive");
        }
        [Route("delAccept")]
        public IActionResult DelAccept(int id)
        {
            seminarAPI.DelAccept(id);
            return RedirectToAction("listSerActive");
        }
    }
}
