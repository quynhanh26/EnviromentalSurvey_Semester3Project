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
    public class QuestionSurveyAPI:IQuestionSurveyAPI
    {
        private string BASE_URL = "http://localhost:5000/api/questionsurvey/";

        public List<QuestionSurvey> Checkquestion(int idsurvey)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.GetAsync("checkquestion/" + idsurvey).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<QuestionSurvey>>(res); ;
                }
                return null;
            }
            catch(Exception e)
            {
                var a = e.Message;
                return null;
            }
        }

        public string Create(QuestionSurvey question)
        {
            try
            {
                var http = new HttpClient();
                http.BaseAddress = new Uri(BASE_URL);
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = http.PostAsJsonAsync("create", question).Result;
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
    }
}
