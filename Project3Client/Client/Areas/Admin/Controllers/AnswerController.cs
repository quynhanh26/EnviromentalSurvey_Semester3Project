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
    [Route("admin/answer")]
    public class AnswerController : Controller
    {

        private IAnswerAPI answerAPI;
        public AnswerController(IAnswerAPI _answerAPI)
        {

            answerAPI = _answerAPI;
        }
        [Route("Del")]
        public IActionResult del(int idAnswer, int idQues)
        {
            var listAnswer = answerAPI.Del(idAnswer, idQues);
            return new JsonResult(listAnswer);
        }
        [Route("Add")]
        public IActionResult Add(Answer answer)
        {
            answer.Id = 0;
            answer.Updated = DateTime.Now;
            var listAnswer = answerAPI.Add(answer);
            return new JsonResult(listAnswer);
        }
        [Route("find")]
        public IActionResult Find(int idAnswer)
        {
            var answer = answerAPI.find(idAnswer);
            return new JsonResult(answer);
        }
        [Route("update")]
        public IActionResult Update(Answer answer)
        {
            answer.Updated = DateTime.Now;
            var listAnswer = answerAPI.Update(answer);
            return new JsonResult(listAnswer);
        }
    }
}
