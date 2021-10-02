﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IScoreService
    {
        List<Score> Top(int n);
        string Create(Score score);
        string CheckExists(int idAcc, int idSurvey);
    }
}
