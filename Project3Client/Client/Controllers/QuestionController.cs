using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("question")]
    public class QuestionController : Controller
    {
        private IQuestionAPI questionAPI;
        private IQuestionSurveyAPI questionsurveyAPI;
        public QuestionController(IQuestionAPI _questionAPI, IQuestionSurveyAPI _questionsurveyAPI)
        {
            questionAPI = _questionAPI;
            questionsurveyAPI = _questionsurveyAPI;
        }
        [Route("index")]
        public IActionResult Index()
        {           
            ViewBag.question = questionAPI.findAll();
            return View();
        }
    }
}
