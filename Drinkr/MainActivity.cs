using Android.App;
using Android.Widget;
using Android.OS;
using Drinkr.Fragments;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using System.Collections.Generic;

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
            
            SetContentView (Resource.Layout.Question);

            //questionFrag = FindViewById<FrameLayout>(Resource.Id.fragmentContainer);

            //QuestionFragment qf = new QuestionFragment();

            //ShowFragment(qf);

            List<QuestionFragment> fff = new List<QuestionFragment>();

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

