using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Client.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/performer")]
    public class PerformerController : Controller
    {
        private IPerformerAPI performerAPI;
        private IWebHostEnvironment webHostEnvironment;
        public PerformerController(IPerformerAPI _performerAPI, IWebHostEnvironment _webHostEnvironment)
        {
            performerAPI = _performerAPI;
            webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.listPer = performerAPI.FindAll2();
            return View();
        }
        [Route("del")]
        public IActionResult Del(int id)
        {
            performerAPI.Del(id);
            return RedirectToAction("Index");
        }
        [Route("create")]
        public IActionResult Create(Performer performer, IFormFile file, bool gender)
        {
           
            performer.Gender = gender;
            performer.Id = 0;
            performer.Status = true;
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/performent", fileName);
                performer.Img = fileName;
                ViewBag.msg = performerAPI.Create(performer);
                if (ViewBag.msg == "Seccuss")
                {
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return RedirectToAction("Index");
                }
            }

            performer.Img = "performerDefault.jpg";
            performerAPI.Create(performer);
            return RedirectToAction("Index");
        }
        [Route("detail")]
        public IActionResult Detail(int id)
        {
            return View(performerAPI.Find(id));
        }
        [Route("update")]
        public IActionResult Update(Performer performer, bool gender, IFormFile file)
        {

            performer.Gender = gender;
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/performent", fileName);
                performer.Img = fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            performerAPI.Update(performer);
            return RedirectToAction("Index");

        }

    }
}

