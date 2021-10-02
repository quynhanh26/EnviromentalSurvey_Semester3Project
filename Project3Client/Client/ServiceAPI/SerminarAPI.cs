using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Client.Models;
using Newtonsoft.Json;

using Client.DTO;
using System.Net.Http.Json;
using System.Diagnostics;

namespace Client.ServiceAPI
{
    public class SerminarAPI : ISeminarAPI
    {
        private string BASE_URL = "http://localhost:5000/api/seminar/";

        public List<SeminarDTO> findAll()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SeminarDTO>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<SeminarDTO> findAll2()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findAll2").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SeminarDTO>>(res);
                }
                return null;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public List<SeminarDTO> findAll3(string idPerson)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findAll3/" + idPerson).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SeminarDTO>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<SeminarDTO> findResent(int n)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                var response = http.GetAsync("findRecent/" + n).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SeminarDTO>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string Create(SeminarDTO seminarDTO)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                var response = http.PostAsJsonAsync("create", seminarDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                return "fails";
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
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.DeleteAsync("del/" + idSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SeminarDTO>>(res);
                }
                return null;
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
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("find/" + idSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Seminar>(res);
                }
                return null;
            }
            catch (Exception e)
            {
                var a = e.Message;
                return null;
            }
        }

        public Seminar updatePre(int idSeminar, string idPre)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("UpdatePre/" + idSeminar + "/" + idPre).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Seminar>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string update(SeminarDTO seminarDTO)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.PutAsJsonAsync("update/", seminarDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<PerformerDTO> delPerforment(int idSeminar, int idPerforment)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("delPer/" + idSeminar + "/" + idPerforment).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<PerformerDTO>>(res);
                }
                return null;
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
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.PostAsJsonAsync("addperforment", performenSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Seminar>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }

        }

        public string CountAccept()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("countAccept").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }

        }
        public List<Seminar> ListAccept()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("listAccept").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Seminar>>(res);
                }
                return null;
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
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.GetAsync("accept/" + idSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string DelAccept(int idSeminar)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.DeleteAsync("delAccept/" + idSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public SeminarDTO FindDTO(int idseminar)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findDTO/" + idseminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<SeminarDTO>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Seminar UpdateNum(int id)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("updatenum/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Seminar>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string CheckMaximum()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("checkmaximum").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return res;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<Seminar> RegisteredSeminar(int id)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("register/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Seminar>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


    }
}
