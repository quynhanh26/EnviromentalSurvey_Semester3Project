using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [Route("comment")]
    public class CommentController : Controller
    {
        private ICommentAPI commentAPI;
        public CommentController(ICommentAPI _commentAPI)
        {
            commentAPI = _commentAPI;
        }
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("index")]
        [HttpPost]
        public IActionResult Index(string message, Comment cmt)
        {
            if (HttpContext.Session.GetString("accounts") != null)
            {
                var curentcmt = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));
                cmt.IdAcc = curentcmt.Id;
                cmt.Massage = message;
                commentAPI.Create(cmt);
                return RedirectToAction(actionName: "Index", controllerName: "home");
            }
            return RedirectToAction(actionName: "Login", controllerName: "account");
        }
    }
}
