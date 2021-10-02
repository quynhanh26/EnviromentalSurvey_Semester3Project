using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Client.ServiceAPI;

namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/account")]
    public class AccountController : Controller
    {
        private IAccountAPI accountAPI;
        private IAllPeopleAPI allPeopleAPI;
        public AccountController(IAccountAPI _accountAPI, IAllPeopleAPI _allPeopleAPI)
        {
            accountAPI = _accountAPI;
            allPeopleAPI = _allPeopleAPI;
        }

        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.listAccount = accountAPI.findAll();
            return View();
        }
        [Route("del")]
        public IActionResult Del(int idAcc)
        {
            var listAcc = accountAPI.Del(idAcc);
            return new JsonResult(listAcc);
        }
        [Route("acceptAccount")]
        public IActionResult AcceptAccount()
        {
            ViewBag.listAccount = accountAPI.AccountActive();
            return View();
        }
        [Route("detailAccount")]
        public IActionResult DetailAccount(int idAccount, string idPerson)
        {
            ViewBag.Count = accountAPI.CountAcc(idPerson);
            ViewBag.Account = accountAPI.find(idAccount);
            ViewBag.InfoPerson = allPeopleAPI.find(idPerson);
            return View();
        }
        [Route("delAccept")]
        public IActionResult DelAccept(int id)
        {
            accountAPI.DelAccept(id);
            return RedirectToAction("acceptAccount");
        }
        [Route("accept")]
        public IActionResult Accept(int id)
        {
            accountAPI.Accept(id);
            return RedirectToAction("acceptAccount");
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
