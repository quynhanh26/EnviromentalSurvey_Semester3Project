using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ServiceAPI
{
   public interface IRegisterSeminarAPI
    {
        List<RegisterSeminar> FindAll();
        string Create(RegisterSeminar register);
        RegisterSeminar find(int id);

        RegisterSeminar FindIdSeminar(int idseminar);
        string CheckExist(int id, int idAcc);
        RegisterSeminar AddSeminar(int id);
    }
}
