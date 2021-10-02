using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
namespace Client.ServiceAPI
{
    public interface ISurveyAPI
    {
        List<Survey> FindAll();
        List<Survey> Findtop(bool active);
        string Create(SurveyDTO survey);
        Survey Find(int idSur);
        string Del(int idSurvey);
        string Update(Survey survey);
        List<QuestionDTO> AddQues(QuestionSurvey questionSurvey);
        List<QuestionDTO> DelQues(QuestionSurvey questionSurvey);
    }
}
