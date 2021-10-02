using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ServiceAPI
{
   public interface IQuestionSurveyAPI
    {
        List<QuestionSurvey> Checkquestion(int idsurvey);
        string Create(QuestionSurvey question);
    }
}
