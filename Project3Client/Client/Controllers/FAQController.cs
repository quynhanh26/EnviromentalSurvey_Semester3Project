using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("faq")]
    public class FAQController : Controller
    {
        private IFaqAPI ifaqAPI;
        public FAQController(IFaqAPI _ifaqAPI)
        {
            ifaqAPI = _ifaqAPI;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var faqs = ifaqAPI.findAll();
            ViewBag.faq = faqs;
            return View();
        }
    }
}
