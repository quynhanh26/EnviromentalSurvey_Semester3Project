using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IAnswerAPI
    {
        List<Answer> findAll();
        Answer find(int idAnswer);
        List<Answer> Add(Answer answer);
        List<Answer> Del(int idAnswer, int idQues);
        List<Answer> Update(Answer answer);
    }
}
