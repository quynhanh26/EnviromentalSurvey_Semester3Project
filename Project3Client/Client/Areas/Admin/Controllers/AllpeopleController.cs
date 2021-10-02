using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Client.Helpers;
using System.IO;

namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/person")]
    public class AllpeopleController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private IAllPeopleAPI allPeopleAPI;
        public AllpeopleController(IAllPeopleAPI _allPeopleAPI, IWebHostEnvironment _webHostEnvironment)
        {
            allPeopleAPI = _allPeopleAPI;
            webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.listPeople = allPeopleAPI.FindAll();
            return View();
        }
        [Route("create")]
        public IActionResult Create(AllPerson allPerson, bool gender, IFormFile file)
        {
            allPerson.IdPerson = RandomHelper.RandomString(8);
            allPerson.Gender = gender;
            allPerson.Status = true;
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/person", fileName);
                allPerson.Img = fileName;
                ViewBag.msg = allPeopleAPI.Create(allPerson);
                if (ViewBag.msg == "Seccuss")
                {
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return RedirectToAction("Index");
                }
            }

            allPerson.Img = "avatarDefault.jpg";
            allPeopleAPI.Create(allPerson);
            return RedirectToAction("Index");
        }
        [Route("del")]
        public IActionResult Del(string id)
        {
            allPeopleAPI.Del(id);
            return RedirectToAction("Index");
        }
        [Route("detail")]
        public IActionResult Detail(string id)
        {
            return View(allPeopleAPI.find(id));
        }
        [Route("update")]
        public IActionResult Update(AllPerson allPerson, bool gender, IFormFile file)
        {

            allPerson.Gender = gender;
            if (file != null)
            {
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var fileName = RandomHelper.RandomString(8) + "." + ext;
                var path = Path.Combine(webHostEnvironment.WebRootPath, "img/person", fileName);
                allPerson.Img = fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            allPeopleAPI.Update(allPerson);
            return RedirectToAction("Index");

        }
    }
}
