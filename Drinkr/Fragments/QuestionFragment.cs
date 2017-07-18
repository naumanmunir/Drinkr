using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Drinkr.Adapters;

namespace Drinkr.Fragments
{
    public class QuestionFragment : Android.Support.V4.App.Fragment
    {
        View view;
        ListView answerListview;
        AnswerAdapter aa;
        string Question;
        List<string> Answers;
        int currIndex = -1;
        Button btnNext;
        TextView txtQuestion;

        public QuestionFragment(string question, List<string> answers)
        {
            Question = question;
            Answers = answers;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.Question, container, false);

            btnNext = view.FindViewById<Button>(Resource.Id.btnNext);
            answerListview = view.FindViewById<ListView>(Resource.Id.lvAnswers);
            aa = new AnswerAdapter(Context);
            answerListview.Adapter = aa;
            answerListview.ItemClick += AnswerListview_ItemClick;
            btnNext.Click += BtnNext_Click;
            return view;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            ChangeQuestionAnswers();
        }

        private void PopulateListViewWithAnswers()
        {

        }

        private void ChangeQuestionAnswers()
        {
            
        }

        private void AnswerListview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var p = e.Parent;
            var v = e.View.FindViewById<RadioButton>(Resource.Id.radioButton1);

            for (int i = 0; i < aa.Count; i++)
            {
                var child = p.GetChildAt(i);

                var rb = child.FindViewById<RadioButton>(Resource.Id.radioButton1);
                rb.Checked = false;
            }

            v.Checked = true;
            Toast.MakeText(Context, v.Text, ToastLength.Short).Show();
        }
    }
}