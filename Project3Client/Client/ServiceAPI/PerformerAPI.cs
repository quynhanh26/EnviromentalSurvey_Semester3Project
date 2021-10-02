using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Client.DTO;
namespace Client.ServiceAPI
{
    public class PerformerAPI : IPerformerAPI
    {
        private string BASE_URL = "http://localhost:5000/api/performer/";

        public List<PerformerDTO> Find2(int idSeminar)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("find2/" + idSeminar).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<PerformerDTO>>(res);
                }
                return null;
            }
            catch (Exception e)
            {
                var a = e.Message;
                return null;
            }
        }
        public Performer Find(int idPer)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("find/" + idPer).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Performer>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Performer> FindAll()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findAll/").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Performer>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Performer> FindAll2()
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                var response = http.GetAsync("findAll2/").Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Performer>>(res);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string Del(int idPerformer)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.DeleteAsync("del/" + idPerformer).Result;
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
        public string Create(Performer performer)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.PostAsJsonAsync("create", performer).Result;
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
        public string Update(Performer performer)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var response = http.PutAsJsonAsync("update", performer).Result;
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
    }
}
