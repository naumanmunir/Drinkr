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
    public interface IRestService
    {
        Task<QuestionList> GetQuestions();

        Task<List<string>> GetCurrentMoods(List<string> answers);

        Task<List<Drink>> GetDrinks(string currMood);
    }
}