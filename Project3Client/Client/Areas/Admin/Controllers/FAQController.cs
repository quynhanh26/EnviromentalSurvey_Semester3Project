using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using Client.Models;
namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/faq")]
    public class FAQController : Controller
    {
        private IFaqAPI faqAPI;
        public FAQController(IFaqAPI _faqAPI)
        {
            faqAPI = _faqAPI;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.listFaq = faqAPI.findAll();
            return View();
        }
        [Route("create")]
        public IActionResult Add(string faq, string answer)
        {
            var listFaq = faqAPI.Create(new FAQ { Faq1 = faq, AnSwer = answer });
            return new JsonResult(listFaq);
        }
        [Route("del")]
        public IActionResult Del(int idFaq)
        {
            var listFaq = faqAPI.Del(idFaq);
            return new JsonResult(listFaq);
        }
        [Route("update")]
        public IActionResult Update(int idFaq, string faq, string answer)
        {
            var listFaq = faqAPI.Update(new FAQ { Id = idFaq, Faq1 = faq, AnSwer = answer });
            return new JsonResult(listFaq);
        }
    }
}
