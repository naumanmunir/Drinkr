﻿using Android.App;
using Android.Widget;
using Android.OS;
using Drinkr.Fragments;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using System.Collections.Generic;
using Drinkr.Models;
using Android.Views.Animations;
using Drinkr.Data;

namespace Drinkr
{
    [Activity(Label = "Drinkr", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        public static RestManager RestManager { get; private set; }
        FrameLayout frameLayout;
        LinearLayout llIntro;
        Button btnEnter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.Main);

            RestManager = new RestManager(new RestService());

            SupportActionBar.Hide();

            frameLayout = FindViewById<FrameLayout>(Resource.Id.fragmentContainer);
            btnEnter = FindViewById<Button>(Resource.Id.btnEnter);
            llIntro = FindViewById<LinearLayout>(Resource.Id.llIntro);

            frameLayout.Visibility = Android.Views.ViewStates.Gone;
            btnEnter.Click += BtnEnter_Click;

            var questionsList = RestManager.GetQuestionsAsync().Result;

            QuestionFragment qf = new QuestionFragment(questionsList);

            ShowFragment(qf);

            //List<QuestionFragment> fff = new List<QuestionFragment>();

            //fff.Add()
        }

        private void BtnEnter_Click(object sender, System.EventArgs e)
        {
            SupportActionBar.Show();
            llIntro.Visibility = Android.Views.ViewStates.Gone;
            frameLayout.Visibility = Android.Views.ViewStates.Visible;

            //Animation slideUp = AnimationUtils.LoadAnimation(this, Resource.Animation.slide_up);
            //Animation slideDown = AnimationUtils.LoadAnimation(this, Resource.Animation.slide_down);

            //llIntro.StartAnimation(slideUp);


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

