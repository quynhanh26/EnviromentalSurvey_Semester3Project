using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Client.Helpers;
using System.IO;

namespace Client.Areas.Staff.Controlles
{
    [Area("Staff")]
    [Route("Staff/seminar")]
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
        [Route("")]
        public IActionResult Index()
        {
            var idPerson = HttpContext.Session.GetString("idPeople");
            ViewBag.listSeminarDTO = seminarAPI.findAll3(idPerson);
            return View();
        }
        [Route("create")]
        public IActionResult Create()
        {
            return View(new SeminarDTO());
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create(SeminarDTO seminarDTO, IFormFile file)
        {
            seminarDTO.Active = false;
            seminarDTO.Presenters = HttpContext.Session.GetString("idPeople");
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
                    return Redirect("/staff/seminar/index");
                }
            }
            else
            {
                seminarDTO.Img = "seminarDefault.png";
                ViewBag.msg = seminarAPI.Create(seminarDTO);
                if (ViewBag.msg == "Seccuss")
                    return Redirect("/staff/seminar/index");

            }
            return View();
        }
        [Route("detail")]
        public IActionResult Details(int idSeminar)
        {
            var seminar = seminarAPI.Find(idSeminar);
            return View(seminar);
        }
        [Route("image")]
        public IActionResult Image(int idSeminar, bool active)
        {
            ViewBag.listImg = imgAPI.GetImgSer(idSeminar);
            ViewBag.idSeminar = idSeminar;
            ViewBag.active = active;
            return View();
        }
        [Route("performent")]
        public IActionResult Performent(int idSeminar, bool active)
        {
            ViewBag.performents = seminarAPI.Find(idSeminar).PerformenSeminars;
            ViewBag.active = active;
            ViewBag.idSeminar = idSeminar;
            return View();
        }
        [Route("update")]
        public IActionResult Update(Seminar seminar, IFormFile file)
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
                Status = true
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
        [Route("delImg")]
        public IActionResult delImg(int idSeminar, int idImg)
        {
            imgAPI.DelImgSer(idSeminar, idImg);
            return RedirectToAction("Image", new { idSeminar = idSeminar, active = false });
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
            return RedirectToAction("Image", new { idSeminar = idSeminar, active = false });
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("accounts");
            HttpContext.Session.Remove("idPeople");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("img");
            return RedirectToAction(actionName: "Login", controllerName: "account");
        }
    }
}
