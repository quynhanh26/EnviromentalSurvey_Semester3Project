using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("img")]
    public class ImgController : Controller
    {
        private IImgAPI imgAPI;
        public ImgController(IImgAPI _imgAPI)
        {
            imgAPI = _imgAPI;
        }
        [Route("gallery")]
        public IActionResult Gallery()
        {
            ViewBag.imgs = imgAPI.FindAll();
            return View();
        }
    }
}
