using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
namespace Client.ServiceAPI
{
    public interface ISeminarAPI
    {
        List<SeminarDTO> findResent(int n);
        List<SeminarDTO> findAll2();
        List<SeminarDTO> findAll3(string idPerson);
        List<SeminarDTO> Del(int idSeminar);
        Seminar Find(int idSeminar);
        Seminar updatePre(int idSeminar, string idPre);
        List<PerformerDTO> delPerforment(int idSeminar, int idPerforment);
        string update(SeminarDTO seminarDTO);
        string Create(SeminarDTO seminarDTO);
        Seminar AddPerforment(PerformenSeminar performenSeminar);
        string CountAccept();
        List<SeminarDTO> findAll();
        List<Seminar> ListAccept();
        string Accept(int idSeminar);
        string DelAccept(int idSeminar);
        SeminarDTO FindDTO(int idseminar);
        string CheckMaximum();
        Seminar UpdateNum(int id);
        List<Seminar> RegisteredSeminar(int id);
    }
}
