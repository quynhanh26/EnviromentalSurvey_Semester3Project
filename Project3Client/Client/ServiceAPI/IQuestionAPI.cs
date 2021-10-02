using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
namespace Client.ServiceAPI
{
    public interface IQuestionAPI
    {
        List<Question> findAll();
        List<Question> findAll2();
        List<Question> Create(Question question);
        List<Question> delQuestion(int idQuestion);
        Question DetailQuestion(int idQuestion);
        Question Update(Question question);
        Question Find(int id);
        string CheckCorrect(int idques, int idans);
        string CountQuestion(bool count, int id);
        List<QuestionDTO> FindByActive(bool n, int id);
        List<QuestionDTO> findQuestion(int idSurvey);
    }
}
