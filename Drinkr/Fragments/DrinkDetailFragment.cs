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

namespace Drinkr.Fragments
{
    public class DrinkDetailFragment : Android.Support.V4.App.Fragment
    {
        Button btnGetRecipe;
        Button btnFindNearBy;
        FrameLayout frameLayout;
        LinearLayout linearLayout;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            

            // Use this to return your custom view for this Fragment
            View view  = inflater.Inflate(Resource.Layout.DrinkDetail, container, false);

            //linearLayout = view.FindViewById<LinearLayout>(Resource.Id.llFinder);
            frameLayout = view.FindViewById<FrameLayout>(Resource.Id.drinkDetailFragContainer);
            btnFindNearBy = view.FindViewById<Button>(Resource.Id.btnFindNearBy);
            btnGetRecipe = view.FindViewById<Button>(Resource.Id.btnFindRecipe);

            btnGetRecipe.Click += BtnGetRecipe_Click;
            btnFindNearBy.Click += BtnFindNearBy_Click;

            //frameLayout.Visibility = ViewStates.Gone;
          
            return view;
        }

        private void BtnGetRecipe_Click(object sender, EventArgs e)
        {
            //linearLayout.Visibility = ViewStates.Visible;
            frameLayout.Visibility = ViewStates.Visible;
            RecipeFragment rf = new RecipeFragment();
            ShowFragment(rf);
        }

        private void BtnFindNearBy_Click(object sender, EventArgs e)
        {
            //linearLayout.Visibility = ViewStates.Visible;
            frameLayout.Visibility = ViewStates.Visible;
            MapFragment mf = new MapFragment();
            ShowFragment(mf);
        }

        private void ShowFragment(Android.Support.V4.App.Fragment frag)
        {
            if (!frag.IsVisible)
            {
                var trans = FragmentManager.BeginTransaction();

                trans.Add(Resource.Id.fragmentContainer, frag);

                //trans.Hide(currSelectedFrag);
                trans.Show(frag);
                trans.AddToBackStack(null);
                trans.Commit();

            }
        }
    }
}