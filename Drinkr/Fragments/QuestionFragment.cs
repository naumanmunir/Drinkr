using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Drinkr.Adapters;
using Drinkr.Models;

namespace Drinkr.Fragments
{
    public class QuestionFragment : Android.Support.V4.App.Fragment
    {
        View view;
        ListView answerListview;
        AnswerAdapter aa;
        QuestionList questionList;
        int currQuestion = 0;
        Button btnNext;
        Button btnBack;
        Button btnDone;
        TextView txtQuestion;
        List<string> selectedAnswers;

        public QuestionFragment(QuestionList questions)
        {
            questionList = questions;
            
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
            btnBack = view.FindViewById<Button>(Resource.Id.btnBack);
            btnDone = view.FindViewById<Button>(Resource.Id.btnDone);
            answerListview = view.FindViewById<ListView>(Resource.Id.lvAnswers);
            txtQuestion = view.FindViewById<TextView>(Resource.Id.txtQuestion);

            selectedAnswers = new List<string>();

            btnBack.Visibility = ViewStates.Gone;
            ChangeQuestion();
            
            answerListview.ItemClick += AnswerListview_ItemClick;
            btnNext.Click += BtnNext_Click;
            btnBack.Click += BtnBack_Click;
            btnDone.Click += BtnDone_Click;
            return view;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            NextFragment();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            currQuestion -= 1;

            if (currQuestion == 0)
            {
                btnBack.Visibility = ViewStates.Gone;
                btnNext.Visibility = ViewStates.Visible;
                ChangeQuestion();
            }
            else
            {
                btnBack.Visibility = ViewStates.Visible;
                btnNext.Visibility = ViewStates.Visible;
                ChangeQuestion();
            }
            


        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currQuestion += 1;

            if (currQuestion == questionList.Questions.Count - 1)
            {
                btnNext.Visibility = ViewStates.Gone;
                btnDone.Visibility = ViewStates.Visible;
                btnBack.Visibility = ViewStates.Visible;
                ChangeQuestion();
            }
            else
            {
                btnBack.Visibility = ViewStates.Visible;
                btnNext.Visibility = ViewStates.Visible;
                ChangeQuestion();
            }
        }

        private void PopulateListViewWithAnswers()
        {
            aa = new AnswerAdapter(Context, questionList.Questions[currQuestion].Answers);
            answerListview.Adapter = aa;
        }

        private void ChangeQuestion()
        {
            txtQuestion.Text = questionList.Questions[currQuestion]._Question;

            PopulateListViewWithAnswers();
        }

        private void TrackNavigation()
        {
            if (currQuestion == 0)
            {
                btnBack.Visibility = ViewStates.Invisible;
            }
            else
            {
                btnBack.Visibility = ViewStates.Visible;
            }

            if (currQuestion == questionList.Questions.Count)
            {
                btnNext.Visibility = ViewStates.Invisible;
            }
            else
            {
                btnBack.Visibility = ViewStates.Visible;
            }
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
            selectedAnswers.Add(v.Text);

        }


        private void NextFragment()
        {
            MoodFragment mf = new MoodFragment(selectedAnswers);

            Android.Support.V4.App.FragmentManager fm = FragmentManager;

            Android.Support.V4.App.FragmentTransaction fragmentTransaction = fm.BeginTransaction();
            fragmentTransaction.Replace(Resource.Id.fragmentContainer, mf);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }
    }
}