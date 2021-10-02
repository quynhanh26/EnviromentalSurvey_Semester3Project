using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.DTO;
using System.Diagnostics;

namespace Client.ServiceAPI
{
    public class SurveyAPI : ISurveyAPI
    {
        private string BASE_URL = "http://localhost:5000/api/survey/";
        public List<Survey> FindAll()
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
                    return JsonConvert.DeserializeObject<List<Survey>>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<Survey> Findtop(bool active)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("findtop/" + active).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Survey>>(res);

                }
                return null;
            }
            catch
            {
               
                return null;
            }
        }
        public string Create(SurveyDTO survey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.PostAsJsonAsync("create", survey).Result;
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
        public string Update(Survey survey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.PutAsJsonAsync("update", survey).Result;
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
        public string Del(int idSurvey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.DeleteAsync("del/" + idSurvey).Result;
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
        public Survey Find(int idSurvey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("Find/" + idSurvey).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Survey>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<QuestionDTO> AddQues(QuestionSurvey questionSurvey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.PostAsJsonAsync("addQes", questionSurvey).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<QuestionDTO>>(res);

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public List<QuestionDTO> DelQues(QuestionSurvey questionSurvey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.DeleteAsync("DelQues/" + questionSurvey.IdQuestion + "/" + questionSurvey.IdSurvey).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<QuestionDTO>>(res);

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
