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
using Drinkr.Models;
using FFImageLoading.Views;
using FFImageLoading;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.Graphics;

using FFImageLoading.Transformations;
using Android.Graphics.Drawables;

namespace Drinkr.Fragments
{
    public class DrinkDetailFragment : Android.Support.V4.App.Fragment
    {
        Drink drink;
        Button btnGetRecipe;
        Button btnFindNearBy;
        TextView drinkDesc;
        FFImageLoading.Views.ImageViewAsync imgDrink;

        FrameLayout frameLayout;
        LinearLayout linearLayout;
        Android.Support.V4.App.Fragment currSelectedFrag;

        public DrinkDetailFragment() { }


        public DrinkDetailFragment(Drink d)
        {
            drink = d;
        }

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
            drinkDesc = view.FindViewById<TextView>(Resource.Id.txtDrinkDesc);
            imgDrink = view.FindViewById<FFImageLoading.Views.ImageViewAsync>(Resource.Id.imgDrink);

            //currSelectedFrag = new DrinkDetailFragment();

            btnGetRecipe.Click += BtnGetRecipe_Click;
            btnFindNearBy.Click += BtnFindNearBy_Click;

            if (string.IsNullOrEmpty(drink.Recipe))
            {
                btnGetRecipe.Visibility = ViewStates.Gone;
            }

            //Bitmap bm = BitmapFactory.DecodeByteArray(drink.Image, 0, drink.Image.Length);

            
            
            ImageService.Instance.LoadStream((token) => { return SomeMethodWhichReturnsStream(token); }).Into(imgDrink);
            
            //imgDrink.SetImageBitmap(bm);

            drinkDesc.Text = drink.Description;

            return view;
        }

        private async Task<Stream> SomeMethodWhichReturnsStream(CancellationToken token)
        {
            if (drink.Image.Length > 0)
            {
                MemoryStream ms = new MemoryStream(drink.Image);

                return await Task.FromResult(ms);
            }

            return null;
        }

        private void BtnGetRecipe_Click(object sender, EventArgs e)
        {
            //linearLayout.Visibility = ViewStates.Visible;
            //frameLayout.Visibility = ViewStates.Visible;
            RecipeFragment rf = new RecipeFragment(drink);
            ShowFragment(rf);
        }

        

        private void BtnFindNearBy_Click(object sender, EventArgs e)
        {
            //linearLayout.Visibility = ViewStates.Visible;
            //frameLayout.Visibility = ViewStates.Visible;
            //MapFragment mf = new MapFragment();
            //ShowFragment(mf);


            var uri = Android.Net.Uri.Parse("geo:" + "40.6059579" + "," + "-74.1533448" + "?q=" + drink.Name);
            Intent intent = new Intent(Intent.ActionView, uri);
            intent.SetPackage("com.google.android.apps.maps");
            StartActivity(intent);
        }

        private void ShowFragment(Android.Support.V4.App.Fragment frag)
        {
            if (!frag.IsVisible)
            {
                var trans = FragmentManager.BeginTransaction();

                //currSelectedFrag = frag;

                trans.Add(Resource.Id.fragmentContainer, frag);

                //trans.Hide(currSelectedFrag);
                trans.Show(frag);
                trans.AddToBackStack(null);
                trans.Commit();

            }
        }
    }
}