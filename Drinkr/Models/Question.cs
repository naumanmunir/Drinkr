﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Drinkr.Models
{
    public class Question
    {
        public string _Question { get; set; }
        public List<string> Answers { get; set; }

    }

    public class QuestionList
    {
        public List<Question> Questions { get; set; }
    }
}