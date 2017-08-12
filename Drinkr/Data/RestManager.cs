using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Drinkr.Models;

namespace Drinkr.Data
{
    public class RestManager
    {
        IRestService restService;

        public RestManager(IRestService service)
        {
            restService = service;
        }

        public Task<QuestionList> GetQuestionsAsync()
        {
            return restService.GetQuestions();
        }

        public Task<List<string>> GetCurrentMoods(List<string> answers)
        {
            return restService.GetCurrentMoods(answers);
        }

        public Task<List<Drink>> GetDrinks(string currMood)
        {
            return restService.GetDrinks(currMood);
        }
    }
}