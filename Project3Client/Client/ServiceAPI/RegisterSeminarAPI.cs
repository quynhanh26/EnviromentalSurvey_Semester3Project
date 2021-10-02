using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Newtonsoft.Json;

namespace Client.ServiceAPI
{
    public class RegisterSeminarAPI : IRegisterSeminarAPI 
    {
        private string BASE_URL = "http://localhost:5000/api/registerseminar/";
        public string Create(RegisterSeminar registerSeminar)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.PostAsJsonAsync("create", registerSeminar).Result;
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

        public List<RegisterSeminar> FindAll()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("findAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<RegisterSeminar>>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public RegisterSeminar find(int id)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("find/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<RegisterSeminar>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public string CheckExist(int id, int idAcc)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.GetAsync("checkexists/" + id+"/"+idAcc).Result;
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

        public RegisterSeminar FindIdSeminar(int idseminar)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("findid/" + idseminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<RegisterSeminar>(res);

                }
                return null;
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
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("addseminar/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<RegisterSeminar>(res);
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
