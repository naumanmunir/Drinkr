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
                var response = client.GetAsync("/api/question/getquestions").Result;
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

        public async Task<List<string>> GetCurrentMoods(List<string> answers)
        {
            var moods = new List<string>();
            string pass = null;

            foreach (var item in answers)
            {
                pass += item + "&answers=";
            }

            try
            {
                string sParams = JsonConvert.SerializeObject(answers);
                
                var h = "/api/question/GetMoodResult?answers=" + sParams;

                var response = client.GetAsync("/api/question/GetMoodResult?answers=" + pass).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    moods = JsonConvert.DeserializeObject<List<string>>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return moods;
        }

        public async Task<List<Drink>> GetDrinks(string currMood)
        {
            var drinkList = new List<Drink>();

            try
            {
                var response = client.GetAsync("/api/question/getdrinks?currmood=" + currMood).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    drinkList = JsonConvert.DeserializeObject<List<Drink>>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return drinkList;
        }

        public async Task<string> AddDrink(string name, string moodID, string desc, string uploadString)
        {
            string res = null;
            var uploadContent = new MultipartFormDataContent()
            {
                { new StringContent(uploadString),  "ImageData" }
            };

            try
            {

                var response = client.PostAsync("/api/question/adddrink/" + name + "/" + moodID + "/" + desc, uploadContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    res = content;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }
    }
}