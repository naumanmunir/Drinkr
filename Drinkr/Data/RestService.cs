using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Drinkr.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Drinkr.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            var authData = string.Format("{0}:{1}", "", "");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.BaseAddress = new Uri("http://www.pichakafoods.com");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<QuestionList> GetQuestions()
        {
            var questionList = new QuestionList();

            try
            {
                var response = client.GetAsync("/api/question").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    questionList = JsonConvert.DeserializeObject<QuestionList>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return questionList;
        }
    }
}