using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IFaqAPI
    {
        List<FAQ> findAll();
        List<FAQ> Create(FAQ faq);
        List<FAQ> Del(int idFaq);
        List<FAQ> Update(FAQ faq);
    }
}
