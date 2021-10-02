using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IRegisterSeminarService
    {
        List<RegisterSeminar> FindAll();
        string Create(RegisterSeminar registerSeminar);
        RegisterSeminar Find(int idregister);
        RegisterSeminar FindIdSeminar(int idseminar);
        string CheckExists(int id, int idAcc);
        RegisterSeminar AddSeminar(int id);
    }
}
