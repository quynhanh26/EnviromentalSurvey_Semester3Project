using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/question")]
    public class QuestionController : Controller
    {
        private IQuestionAPI questionAPI;
        private IAnswerAPI answerAPI;
        public QuestionController(IQuestionAPI _questionAPI, IAnswerAPI _answerAPI)
        {
            questionAPI = _questionAPI;
            answerAPI = _answerAPI;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.listQuestion = questionAPI.findAll();

            return View();
        }
        [Route("delQuestion")]
        public IActionResult DelQuestion(int idQues)
        {

            questionAPI.delQuestion(idQues);
            return RedirectToAction("Index");
        }
        [Route("detailQues")]
        public IActionResult DetailQuestion(int idQues)
        {
            var question = questionAPI.DetailQuestion(idQues);
            ViewBag.Question = question;
            ViewBag.listAnswer = question.Answers;
            return View();
        }
        [Route("create")]
        public IActionResult Create(Question question)
        {
            question.Updated = DateTime.Now;
            question.Status = true;
            var listQuestion = questionAPI.Create(question);
            return new JsonResult(listQuestion);
        }
        [Route("update")]
        public IActionResult update(int idQuestion, string question, bool statusQuestion)
        {
            questionAPI.Update(new Question { Id = idQuestion, Question1 = question, Status = statusQuestion });
            return RedirectToAction("DetailQuestion", new { idQues = idQuestion });
        }
    }
}
