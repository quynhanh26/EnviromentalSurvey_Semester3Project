﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
using System.Diagnostics;

namespace Server.Services
{
    public class SeminarServiceImpl : ISeminarService
    {
        private readonly DatabaseContext db;
        public SeminarServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Seminar seminar)
        {
            try
            {
                db.Seminars.Add(seminar);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<SeminarDTO> Del(int idSeminar)
        {
            try
            {
                db.Seminars.Find(idSeminar).Status = false;
                db.SaveChanges();
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        select
                        new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<PerformerDTO> DelPerforment(int idSeminar, int idPerforment)
        {
            try
            {
                var temp = db.PerformenSeminars.SingleOrDefault(e => e.IdPerforment == idPerforment && e.IdSeminar == idSeminar);
                db.PerformenSeminars.Remove(temp);
                db.SaveChanges();
                return (from a in db.PerformenSeminars
                        join s in db.Performers on a.IdPerforment equals s.Id
                        where a.IdSeminar == idSeminar
                        select new PerformerDTO { Id = s.Id, Img = s.Img, Dob = s.Dob, Name = s.Name, Gender = s.Gender, Status = s.Status, }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Seminar Find(int idSeminar)
        {
            try
            {
                return db.Seminars.Find(idSeminar);
            }
            catch
            {
                return null;
            }
        }


        public List<SeminarDTO> FindAll()
        {
            try
            {

                var a = db.Seminars.Where(e => e.Status == true && e.Active == true).OrderByDescending(s => s.Id).Select(s =>
                 new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, Presenters = s.Presenters, TimeStart = s.TimeStart.ToString(), TimeEnd = s.TimeEnd.ToString(), Day = s.Day, Place = s.Place, Maximum = s.Maximum, Descriptoin = s.Descriptoin, Status = s.Status }).ToList();
                return a;
            }
            catch
            {
                return null;
            }
        }
        public List<SeminarDTO> FindAll2()
        {
            try
            {
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        where s.Active == true
                        select
                        new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).ToList();
            }
            catch (Exception e)
            {
                var a = e.Message;
                return null;
            }
        }
        public List<SeminarDTO> FindAll3(string idPerson)
        {
            try
            {
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        where s.Presenters == idPerson
                        select
                        new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status, Active = s.Active }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public SeminarDTO FindDTO(int idSeminar)
        {
            try
            {
                var seminarDTO = (SeminarDTO)(from s in db.Seminars
                                              join p in db.AllPeople on s.Presenters equals p.IdPerson
                                              where s.Id == idSeminar
                                              select new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, Presenters = s.Presenters, NamePresenters = p.Name, TimeStart = s.TimeStart.ToString(), TimeEnd = s.TimeEnd.ToString(), Day = s.Day, Place = s.Place, Maximum = s.Maximum, Descriptoin = s.Descriptoin, Status = s.Status }).SingleOrDefault();
                return seminarDTO;

            }
            catch(Exception e)
            {
                var a = e.Message;
                return null;
            }
        }

        public List<SeminarDTO> RecentSeminar(int n)
        {
            try
            {
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        where s.Day < DateTime.Now && s.Status == true
                        orderby s.Day descending
                        select
                        new SeminarDTO { Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).Take(n).ToList();

            }
            catch
            {
                return null;
            }
        }

        public string Update(SeminarDTO seminarDTO)
        {
            try
            {
                var seminar = db.Seminars.Find(seminarDTO.Id);
                if (seminarDTO.Img != null) seminar.Img = seminarDTO.Img;
                seminar.Name = seminarDTO.Name;
                seminar.TimeStart = TimeSpan.Parse(seminarDTO.TimeStart);
                seminar.TimeEnd = TimeSpan.Parse(seminarDTO.TimeEnd);
                seminar.Day = seminarDTO.Day;
                seminar.Place = seminarDTO.Place;
                seminar.Maximum = seminarDTO.Maximum;
                seminar.Descriptoin = seminarDTO.Descriptoin;
                seminar.Status = seminarDTO.Status;

                db.SaveChanges();
                return seminar.Id.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public Seminar UpdatePre(int idSeminar, string idPrecenter)
        {
            try
            {
                var seminar = db.Seminars.Find(idSeminar);
                seminar.Presenters = idPrecenter;
                db.SaveChanges();
                return seminar;
            }
            catch
            {
                return null;
            }
        }
        public Seminar AddPerforment(PerformenSeminar performenSeminar)
        {
            try
            {
                var seminar = db.Seminars.Find(performenSeminar.IdSeminar);
                var performent = db.Performers.Find(performenSeminar.IdPerforment);
                performent.PerformenSeminars.Add(performenSeminar);
                seminar.PerformenSeminars.Add(performenSeminar);
                db.SaveChanges();
                return db.Seminars.Find(performenSeminar.IdSeminar);
            }
            catch
            {
                return null;
            }
        }

        public int CountAccept()
        {
            try
            {
                return db.Seminars.Where(e => e.Active == false).Count();
            }
            catch
            {
                return 0;
            }
        }
        public List<Seminar> ListAccept()
        {
            try
            {
                return db.Seminars.Where(e => e.Active == false).ToList();
            }
            catch
            {
                return null;
            }
        }
        public string Accept(int idSeminar)
        {
            try
            {
                db.Seminars.Find(idSeminar).Active = true;
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DelAccept(int idSeminar)
        {
            try
            {
                db.Seminars.Remove(db.Seminars.Find(idSeminar));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string CheckDateSeminar()
        {
            try
            {
                return db.Seminars.Count(s => s.Day < DateTime.Now && s.Status == true).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string CheckMaximum()
        {
            try
            {
                return db.Seminars.Count(s => s.Maximum == s.NumberOfParticipants).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Seminar> RegisteredSeminar(int id)
        {
            try
            {
                return (from s in db.Seminars
                        join r in db.RegisterSeminars on s.Id equals r.IdSeminar
                        where r.IdAcc == id
                        select new Seminar
                        {
                            Name = s.Name,
                            Presenters = s.Presenters,
                            TimeStart = s.TimeStart,
                            Day = s.Day,
                            Place = s.Place,
                            Active =s.Active,
                            Descriptoin =s.Descriptoin,
                            Img =s.Img,
                            Maximum =s.Maximum,
                            NumberOfParticipants =s.NumberOfParticipants,
                            Status =s.Status,
                            TimeEnd =s.TimeEnd,
                        }).ToList();
            }
            catch
            {

                return null;
            }
        }


        public Seminar UpdateNumber(int id)
        {
            try
            {
                var seminar = db.Seminars.Find(id);
                seminar.NumberOfParticipants += 1;
                db.SaveChanges();
                return seminar;
            }
            catch
            {
                return null;
            }
        }
    }
}
