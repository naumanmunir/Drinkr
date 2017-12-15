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
using AppIntro;

namespace Drinkr
{
    [Activity(Label = "IntroActivity", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class IntroActivity : AppIntro.AppIntro
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddSlide(AppIntroFragment.NewInstance("Drinkr", "Find your current mood", Resource.Drawable.drinkimg1, Android.Graphics.Color.ParseColor("#4EBDD1")));
            AddSlide(AppIntroFragment.NewInstance("Drinkr", "Find drinks that can help elevate your mood", Resource.Drawable.drinkimg1, Android.Graphics.Color.ParseColor("#4EBDD1")));
            AddSlide(AppIntroFragment.NewInstance("Drinkr", "Drinkr helps you find these drinks near by", Resource.Drawable.drinkimg1, Android.Graphics.Color.ParseColor("#4EBDD1")));
            AddSlide(AppIntroFragment.NewInstance("Drinkr", "Or you can make the drinks yourselves with the recipes provided!", Resource.Drawable.drinkimg1, Android.Graphics.Color.ParseColor("#4EBDD1")));
            //SetFadeAnimation();
            SetDepthAnimation();

            SupportActionBar.Hide();
        }

        public override void OnSkipPressed()
        {
            base.OnSkipPressed();
            Finish();
        }

        public override void OnDonePressed()
        {
            base.OnDonePressed();
            Finish();
        }

        public override void OnSlideChanged()
        {
            base.OnSlideChanged();
        }


    }
}