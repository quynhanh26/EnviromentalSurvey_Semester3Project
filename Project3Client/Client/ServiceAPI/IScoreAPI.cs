using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IScoreAPI
    {
        List<Score> Top(int n);
        string Create(Score score);
        string CheckExists(int idAcc, int idSurvey);
    }
}
