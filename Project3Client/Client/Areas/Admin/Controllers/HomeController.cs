using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http.Json;
using Client.Models;
using Newtonsoft.Json;
using Client.ServiceAPI;
namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        private ISeminarAPI seminarAPI;
        private IScoreAPI scoreAPI;
        private ICommentAPI commentAPI;
        public HomeController(ISeminarAPI _seminarAPI, IScoreAPI _scoreAPI, ICommentAPI _commentAPI)
        {
            seminarAPI = _seminarAPI;
            scoreAPI = _scoreAPI;
            commentAPI = _commentAPI;
        }
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.listSeminarDTO = seminarAPI.findResent(4);
            ViewBag.listCmtDTO = commentAPI.FindAll2();
            return View();
        }
    }
}
