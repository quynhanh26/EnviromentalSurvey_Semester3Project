using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface IPerformerService
    {
        List<Performer> FindAll();
        List<Performer> FindAll2();
        Performer Find(int idPerformer);
        string Create(Performer performer);
        string Del(int idPerformer);
        string Update(Performer performer);
        List<PerformerDTO> Find2(int idSeminar);
    }
}
