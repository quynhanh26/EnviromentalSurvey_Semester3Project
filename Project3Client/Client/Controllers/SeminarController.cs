using Client.DTO;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Route("seminar")]
    public class SeminarController : Controller
    {
        private IAccountAPI accountAPI;
        private ISeminarAPI seminarAPI;
        private IRegisterSeminarAPI registerseminarAPI;
        public SeminarController(ISeminarAPI _seminarAPI, IAccountAPI _accountAPI, IRegisterSeminarAPI _registerseminarAPI)
        {
            seminarAPI = _seminarAPI;
            accountAPI = _accountAPI;
            registerseminarAPI = _registerseminarAPI;
        }
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.seminars = seminarAPI.findAll();
            return View();
        }
        [HttpGet]
        [Route("detail/{id}")]
        public IActionResult Detail(int id)
        {
            return View("Detail", seminarAPI.FindDTO(id));
        }
        [HttpPost]
        [Route("detail/{id}")]
        public IActionResult Detail(Seminar seminar, RegisterSeminar registerseminar)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var id = accountAPI.find((int)HttpContext.Session.GetInt32("id"));
                if (registerseminarAPI.CheckExist(seminar.Id, id.Id) != "1")
                {
                    if (seminarAPI.CheckMaximum() != "\"1\"")
                    {
                        registerseminar.IdAcc = id.Id;
                        registerseminar.IdSeminar = seminar.Id;
                        registerseminar.Status = true;
                        if(registerseminar != null)
                        {
                            var seminarres = seminarAPI.Find(seminar.Id);
                            registerseminarAPI.Create(new RegisterSeminar
                            {
                                IdAcc = id.Id,
                                IdSeminar = seminar.Id,
                                Status = true
                            });
                            seminarAPI.UpdateNum(seminarres.Id);                         

                        }
                        ViewBag.msg1 = "Thank you for registering!";
                        ViewBag.seminars = seminarAPI.findAll();
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.seminars = seminarAPI.findAll();
                        ViewBag.msg1 = "Enough number of participants, you can subscribe to the next workshop. Thank you!";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.seminars = seminarAPI.findAll();
                    ViewBag.msg1 = "You have registered this workshop. Thank you!";
                    return View("Index");
                }

            }
            return RedirectToAction(actionName: "Login", controllerName: "account");

        }
        [HttpGet]
        [Route("registeredseminar")]
        public IActionResult RegisteredSeminar()
        {
            if(HttpContext.Session.GetString("accounts") != null)
            {
                var account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));

               var registeredseminar = seminarAPI.RegisteredSeminar(account.Id);
                if(registeredseminar ==null)
                {
                    ViewBag.msg = "You have not registered any workshop";
                }
                else
                {
                    ViewBag.seminar = registeredseminar;
                }
                
                return View();
            }
            return RedirectToAction(actionName: "Login", controllerName: "account");
            }
    }
}
