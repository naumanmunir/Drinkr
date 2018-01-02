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
using Drinkr.Data;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V7.App;

namespace Drinkr.Fragments
{
    public class MainFragment : Android.Support.V4.App.Fragment
    {
        public static RestManager RestManager { get; private set; }
        FrameLayout frameLayout;
        LinearLayout llIntro;
        Button btnEnter;
        Button btnAdmin;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Main, container, false);

            frameLayout = view.FindViewById<FrameLayout>(Resource.Id.fragmentContainer);
            btnEnter = view.FindViewById<Button>(Resource.Id.btnEnter);
            btnAdmin = view.FindViewById<Button>(Resource.Id.btnAdmin);
            llIntro = view.FindViewById<LinearLayout>(Resource.Id.llIntro);

            btnEnter.Click += BtnEnter_Click;
            btnAdmin.Click += BtnAdmin_Click;

            return view;
        }

        private void BtnAdmin_Click(object sender, System.EventArgs e)
        {
            AdminFragment af = new AdminFragment();

            llIntro.Visibility = Android.Views.ViewStates.Gone;
            frameLayout.Visibility = Android.Views.ViewStates.Visible;

        }

        private void BtnEnter_Click(object sender, System.EventArgs e)
        {
            var questionsList = RestManager.GetQuestionsAsync().Result;
            QuestionFragment qf = new QuestionFragment(questionsList);

            llIntro.Visibility = Android.Views.ViewStates.Gone;
            frameLayout.Visibility = Android.Views.ViewStates.Visible;

            //Animation slideUp = AnimationUtils.LoadAnimation(this, Resource.Animation.slide_up);
            //Animation slideDown = AnimationUtils.LoadAnimation(this, Resource.Animation.slide_down);

            //llIntro.StartAnimation(slideUp);
        }
    }
}