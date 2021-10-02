using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
using Client.DTO;

namespace Client.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/survey")]
    public class SurveyController : Controller
    {
        private readonly ISurveyAPI surveyAPI;
        private readonly IQuestionAPI questionAPI;
        public SurveyController(ISurveyAPI _surveyAPI, IQuestionAPI _questionAPI)
        {
            surveyAPI = _surveyAPI;
            questionAPI = _questionAPI;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.listSurvey = surveyAPI.FindAll();
            return View();
        }
        [Route("create")]
        public IActionResult Create()
        {

            ViewBag.listQues = questionAPI.findAll2();
            return View();
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create(string name, DateTime updated, string active, string des, int[] arrayQues)
        {
            var survey = new SurveyDTO
            {
                Id = 0,
                Name = name,
                Updated = updated,
                Active = active == "1" ? true : false,
                Status = true,
                ListQues = arrayQues.ToList(),
                Description = des
            };
            surveyAPI.Create(survey);
            return RedirectToAction(actionName: "Index", controllerName: "survey", new { area = "admin" });
        }
        [Route("Detail")]
        public IActionResult Detail(int id)
        {
            ViewBag.sur = surveyAPI.Find(id);
            return View();
        }
        [Route("del")]
        public IActionResult Del(int id)
        {
            surveyAPI.Del(id);
            return Redirect("/admin/survey/index");
        }
       
        [Route("update")]
        public IActionResult Update(int id)
        {
            return View(surveyAPI.Find(id));
        }
        [Route("update")]
        [HttpPost]
        public IActionResult Update(Survey survey)
        {
            surveyAPI.Update(survey);
            return Redirect("/admin/survey/index");
        }
        [Route("findQuestion")]
        public IActionResult FindQuestion(int idSurvey)
        {
            var question = questionAPI.findQuestion(idSurvey);
            return new JsonResult(question);
        }
        [Route("addQues")]
        public IActionResult AddQuestion(int idSurvey, int idQuestion)
        {
            var quesSur = new QuestionSurvey
            {
                IdQuestion = idQuestion,
                IdSurvey = idSurvey,
                Updated = DateTime.Now,
                Status = true
            };
            var question = surveyAPI.AddQues(quesSur);
            return new JsonResult(question);
        }
        [Route("delQues")]
        public IActionResult DelQues(int idSurvey, int idQuestion)
        {
            var quesSur = new QuestionSurvey
            {
                IdQuestion = idQuestion,
                IdSurvey = idSurvey,
            };
            var question = surveyAPI.DelQues(quesSur);
            return new JsonResult(question);
        }
    }
}
