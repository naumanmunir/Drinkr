using Android.App;
using Android.Widget;
using Android.OS;
using Drinkr.Fragments;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using System.Collections.Generic;
using Drinkr.Models;

namespace Drinkr
{
    [Activity(Label = "Drinkr", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        int numOfFragments = 5;
        //private FrameLayout questionFrag;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.Main);

            //questionFrag = FindViewById<FrameLayout>(Resource.Id.fragmentContainer);

            List<Question> Question = new List<Question>();

            Question q = new Models.Question();
            q._Question = "Whats your favorite color?";
            q.Answers = new List<string>() { "Red", "Yellow", "Black" };

            Question q1 = new Models.Question();
            q1._Question = "How are you feeling?";
            q1.Answers = new List<string>() { "Tired", "Happy", "Fu*k you!" };

            Question q2 = new Models.Question();
            q2._Question = "How was your lunch today?";
            q2.Answers = new List<string>() { "Boring!", "fulling!", "It was O.K" };

            Question.Add(q);
            Question.Add(q1);
            Question.Add(q2);
            QuestionFragment qf = new QuestionFragment(Question);

            ShowFragment(qf);

            //List<QuestionFragment> fff = new List<QuestionFragment>();

            //fff.Add()
        }

        private void ShowFragment(SupportFragment frag)
        {
            if (!frag.IsVisible)
            {

                var trans = SupportFragmentManager.BeginTransaction();

                trans.Add(Resource.Id.fragmentContainer, frag);

                //trans.Hide(currSelectedFrag);
                trans.Show(frag);
                trans.AddToBackStack(null);
                trans.Commit();

                //currSelectedFrag = frag;
            }
        }
    }
}

