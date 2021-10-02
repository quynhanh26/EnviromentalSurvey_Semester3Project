using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
namespace Client.ServiceAPI
{
    public interface IPerformerAPI
    {
        List<PerformerDTO> Find2(int idSeminar);
        Performer Find(int idSeminar);
        List<Performer> FindAll();
        List<Performer> FindAll2();
        string Del(int idPerformer);
        string Create(Performer performer);
        string Update(Performer performer);
    }
}
