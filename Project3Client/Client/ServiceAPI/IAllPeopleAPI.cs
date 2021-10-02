using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IAllPeopleAPI
    {
        List<AllPerson> findStaff();
        AllPerson find(string idPerson);
        List<AllPerson> FindAll();
        string Create(AllPerson allPerson);
        string Del(string idPeson);
        string Update(AllPerson allPerson);
    }
}
