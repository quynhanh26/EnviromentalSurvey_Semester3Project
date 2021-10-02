using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [Route("survey")]
    public class SurveyController : Controller
    {
        private ISurveyAPI surveyAPI;
        private IQuestionAPI questionAPI;
        private IQuestionSurveyAPI questionsurveyAPI;
        private IScoreAPI scoreAPI;
        private IAccountAPI accountAPI;
        public SurveyController(IQuestionAPI _questionAPI, IQuestionSurveyAPI _questionsurveyAPI, ISurveyAPI _surveyAPI, IScoreAPI _scoreAPI, IAccountAPI _accountAPI)
        {
            questionAPI = _questionAPI;
            questionsurveyAPI = _questionsurveyAPI;
            surveyAPI = _surveyAPI;
            scoreAPI = _scoreAPI;
            accountAPI = _accountAPI;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("accounts") != null) 
            {
                var account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));
                if (account.Role == "nv" || account.Role == "gv")
                {
                    ViewBag.survey = surveyAPI.Findtop(true);
                }
                else if (account.Role == "sv")
                {
                    ViewBag.survey = surveyAPI.Findtop(false);
                }
                return View();
            }
            return View();
        }
        [HttpGet]
        [Route("question/{id}")]
        public IActionResult Question(int id)
        {
            var account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("accounts"));
            if (scoreAPI.CheckExists((int)HttpContext.Session.GetInt32("id"), id) != "\"1\"")
            {
                
                if (questionsurveyAPI.Checkquestion(id) != null)
                {

                    if (account.Role == "gv")
                    {
                        ViewBag.question = questionAPI.FindByActive(true, id);
                    }
                    else if (account.Role == "sv")
                    {
                        ViewBag.question = questionAPI.FindByActive(false, id);
                    }
                    return View("Question");
                }
                if (account.Role == "gv")
                {
                    ViewBag.survey = surveyAPI.Findtop(true);

                }
                else if (account.Role == "sv")
                {
                    ViewBag.survey = surveyAPI.Findtop(false);
                }
                return View("Index");

            }
            ViewBag.msg1 = "You have registered to participate in the survey. See you in the next survey!";
            if (account.Role == "nv" || account.Role == "gv")
            {
                ViewBag.survey = surveyAPI.Findtop(true);
            }
            else if (account.Role == "sv")
            {
                ViewBag.survey = surveyAPI.Findtop(false);
            }
            return View("Index");
        }
        [HttpPost]
        [Route("question/{id}")]
        public IActionResult Question(Score score, IFormCollection formCollection, int id)
        {
                var account = accountAPI.find((int)HttpContext.Session.GetInt32("id"));
                if (account.Role == "gv")
                {
                    double score1 = 0;
                    double quesgv = double.Parse(questionAPI.CountQuestion(true, id));
                    double questiongv = 10 / quesgv;
                    foreach (var questions in questionAPI.findAll())
                    {
                        var answerId = formCollection["question_" + questions.Id];
                        if (!string.IsNullOrEmpty(answerId))
                        {
                            var answers = Int32.Parse(formCollection["question_" + questions.Id]);
                            if (questionAPI.CheckCorrect(questions.Id, answers) != null)
                            {

                                score1 = score1 + questiongv;
                            }
                        }
                    }
                    score.Score1 = (int?)Math.Round(score1,2);
                    ViewBag.score = score.Score1;
                    ViewBag.survey = surveyAPI.Findtop(true);
                }
                else if (account.Role == "sv")
                {
                    double ques = double.Parse(questionAPI.CountQuestion(false, id));
                    double question =10 / ques;
                    double score2 = 0;
                    foreach (var questions in questionAPI.FindByActive(false, id))
                    {
                        var answerId = formCollection["question_" + questions.Id];
                        if (!string.IsNullOrEmpty(answerId))
                        {
                            var answers = Int32.Parse(formCollection["question_" + questions.Id]);
                            if (questionAPI.CheckCorrect(questions.Id, answers) == "\"True\"")
                            {

                                score2 = score2 + question;
                            }
                        }
                    }
                    score.Score1 = (int?)Math.Round(score2,2);
                    ViewBag.score = score.Score1;
                    ViewBag.survey = surveyAPI.Findtop(false);
                }
                score.IdAcc = account.Id;
                score.IdSurvey = id;
                score.Status = true;
                scoreAPI.Create(score);
                ViewBag.score = score.Score1;
                return View("Index");
        }
    }
}
