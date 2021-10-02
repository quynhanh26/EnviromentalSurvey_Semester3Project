using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Client.Helpers;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private IAccountAPI accountAPI;
        public AccountController(IAccountAPI _accountAPI, IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
            accountAPI = _accountAPI;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var acc = accountAPI.login(new Account { UserName = username, Password = password });
            if (acc == null) return View();
            HttpContext.Session.SetString("accounts", JsonConvert.SerializeObject(acc));
            Debug.WriteLine(HttpContext.Session.GetString("accounts"));
            HttpContext.Session.SetString("username", acc.UserName);
            HttpContext.Session.SetString("idPeople", acc.IdPeople);
            HttpContext.Session.SetInt32("id", acc.Id);
            HttpContext.Session.SetString("role", acc.Role);
            HttpContext.Session.SetString("img", acc.Img);
            return acc.Role switch
            {
                "nv" => RedirectToAction(actionName: "Index", controllerName: "seminar", new {area ="staff"}),
                "gv" => RedirectToAction(actionName: "Index", controllerName: "home"),
                "sv" => RedirectToAction(actionName: "Index", controllerName: "home"),
                "admin" => RedirectToAction(actionName: "Index", controllerName: "home", new { area = "admin" }),
                _ => RedirectToAction(actionName: "Login", controllerName: "account")
            };
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("Register", new Account());
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(Account acc, string pass, string connfirmpass)
        {

            if (accountAPI.CheckMail(acc.Email) != "1")
            {
                if (pass == connfirmpass)
                {
                    acc.Img = "avatar.jpg";
                    acc.Status = true;
                    acc.Password = BCrypt.Net.BCrypt.HashPassword(pass);
                    acc.Active = false;
                    HttpContext.Session.SetString("email", acc.Email);
                    var subject = "Confirmation code only in 60s";
                    var content = RandomHelper.RandomString(5);
                    var isHtml = true;
                    HttpContext.Session.SetString("content", content);
                    MailHelper.Send(acc.Email, subject, content, isHtml);
                    HttpContext.Session.SetString("account", JsonConvert.SerializeObject(acc));                   
                }
                return View("CheckMail", acc);
            }
            return View("Register");
        }
        [Route("profile")]
        [HttpGet]
        public IActionResult Profile()
        {
            var acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));
            return View("Profile", acc);
        }
        [Route("profile")]
        [HttpPost]
        public IActionResult Profile(string oldpassword, string newpass, string confirmpass, Account acc, IFormFile file)
        {
            var newacc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));
            Debug.WriteLine(newacc);
            var currentAcc = accountAPI.find(newacc.Id);
            if (acc != null)
            {
                if (!string.IsNullOrEmpty(newpass))
                {
                    if (BCrypt.Net.BCrypt.Verify(oldpassword, currentAcc.Password) && newpass == confirmpass)
                    {
                        acc.Password = newpass;
                    }
                }
                else
                {
                    acc.Password = currentAcc.Password;
                }

                if (file != null)
                {
                    var fileName = System.Guid.NewGuid().ToString().Replace("-", "");
                    var ext = file.ContentType.Split(new char[] { '/' })[1];
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "img/avatar", fileName + "." + ext);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    acc.Img = fileName + "." + ext;
                }
                else
                {
                    acc.Img = newacc.Img;
                }
                acc.Class = currentAcc.Class;
                acc.Date = currentAcc.Date;
                acc.UserName = acc.UserName;
                acc.Email = currentAcc.Email;
                acc.Role = newacc.Role;
                acc.Status = currentAcc.Status;
                acc.Active = currentAcc.Active;
                accountAPI.Update(new Account
                {
                    Id = newacc.Id,
                    Email = acc.Email,
                    Password = acc.Password,
                    UserName = acc.UserName,
                    Img = acc.Img,

                });
                ViewBag.success = "Update Profile success";
                if (acc.UserName != newacc.UserName)
                {
                    HttpContext.Session.Remove("accounts");
                    HttpContext.Session.Remove("username");
                    HttpContext.Session.SetString("username", acc.UserName);
                    HttpContext.Session.SetString("accounts", JsonConvert.SerializeObject(acc));
                }
                if (string.IsNullOrEmpty(newpass))
                {
                    return View("Profile", acc);
                }
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("accounts");
            return View("login");
        }
        [HttpGet]
        [Route("forgotpass")]
        public IActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        [Route("forgotpass")]
        public IActionResult ForgotPass(string email)
        {
            if (accountAPI.CheckMail(email) == "1")
            {
                HttpContext.Session.SetString("email", email);
                var subject = "Confirmation code only in 60s";
                var content = RandomHelper.RandomString(5);
                HttpContext.Session.SetString("content", content);
                var isHtml = true;
                MailHelper.Send(email, subject, content, isHtml);
                ViewBag.msg1 = "email sent success";
                return View("Resetpass", email);
            }
            ViewBag.msg = "Your account does not exist";
            return View("Register");
        }
        [HttpGet]
        [Route("resetpass/{email}")]
        public IActionResult ResetPass(string numcode)
        {

            var content = HttpContext.Session.GetString("content");
            if (numcode == content)
            {
                HttpContext.Session.Remove("content");
                return View("ResetPass");
            }
            return View("Register");
        }
        [HttpPost]
        [Route("resetpass")]
        public IActionResult ResetPass(string newpass, string pass)
        {
            var email = HttpContext.Session.GetString("email");
            var currentAcc = accountAPI.FindMail(email);
            if (newpass == pass)
            {
                currentAcc.Password = BCrypt.Net.BCrypt.HashPassword(pass);
            }
            accountAPI.UpdatePass(new Account
            {
                Email = email,
                Password = currentAcc.Password
            });
            HttpContext.Session.Remove("email");
            return View("Login");
        }
        [HttpGet]       
        [Route("checkmail")]
        public IActionResult CheckMail()
        {          
            return View("CheckMail");
        }
        [HttpPost]
        [Route("checkmail")]
        public IActionResult CheckMail(Account acc, string numcode)
        {
            var email = HttpContext.Session.GetString("email");
            if (accountAPI.CheckMail(email) == "0")
            {
                var content = HttpContext.Session.GetString("content");
                if (numcode == content)
                {
                    acc = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("account"));
                    ViewBag.checkmailsuccess = "Successful registration";
                    accountAPI.Register(acc);
                }
                return View("Register");
            }
            ViewBag.checkmailsuccess = "Your account does not exist";
            return View("Register");
        }
        [Route("top")]
        public IActionResult Top()
        {
            ViewBag.top = accountAPI.FindTop();
            return View();
        }
    }
}