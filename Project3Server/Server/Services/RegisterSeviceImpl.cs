using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class RegisterSeviceImpl : IRegisterSeminarService
    {
        private readonly DatabaseContext db;
        public RegisterSeviceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(RegisterSeminar registerSeminar)
        {
            try
            {
                db.RegisterSeminars.Add(registerSeminar);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<RegisterSeminar> FindAll()
        {
            try
            {
                return db.RegisterSeminars.ToList();
            }
            catch
            {
                return null;
            }
        }
        public RegisterSeminar Find(int idregister)
        {
            try
            {
                return db.RegisterSeminars.Find(idregister);
            }
            catch
            {
                return null;
            }
        }
        public string CheckMail(string mail)
        {
            try
            {

                return db.Accounts.Count(a => a.Email == mail).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string CheckExists(int id, int idAcc)
        {
            try
            {
                return db.RegisterSeminars.Count(rs => rs.IdAcc == idAcc && rs.IdSeminar == id).ToString();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public RegisterSeminar FindIdSeminar(int idseminar)
        {
            try
            {
                return db.RegisterSeminars.Find(idseminar);
            }
            catch
            {
                return null;
            }
        }
        public RegisterSeminar AddSeminar(int id)
        {
            try
            {
                return db.RegisterSeminars.Find(id);
            }
            catch
            {

                return null;
            }
        }
    }
}

