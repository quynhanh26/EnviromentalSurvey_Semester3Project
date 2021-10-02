using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IAccountAPI
    {
        string CountActive();
        List<Account> findAll();
        Account login(Account account);
        List<Account> Del(int idAcc);
        List<Account> AccountActive();
        Account find(int idAcc);
        string Accept(int idAcc);
        string DelAccept(int idAcc);
        string CountAcc(string idAcc);

        string Register(Account account);
        string CheckMail(string mail);
        string Update(Account account);
        string UpdatePass(Account account);
        Account FindMail(string mail);
        List<Account> FindTop();
    }
}
