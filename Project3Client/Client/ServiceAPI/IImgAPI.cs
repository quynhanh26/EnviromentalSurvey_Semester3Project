using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
namespace Client.ServiceAPI
{
    public interface IImgAPI
    {
        List<Img> GetImgSer(int idSeminar);
        string DelImgSer(int idSeminar, int idImg);
        string AddImgSer(Img img);
        List<Img> FindAll();
    }
}
