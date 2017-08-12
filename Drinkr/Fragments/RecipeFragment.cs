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
using Android.Text;

namespace Drinkr.Fragments
{
    public class RecipeFragment : Android.Support.V4.App.Fragment
    {
        Drink drink;
        TextView txtDrinkTitle;
        TextView txtRecipe;

        public RecipeFragment(Drink d)
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
            View view = inflater.Inflate(Resource.Layout.Recipe, container, false);

            txtDrinkTitle = view.FindViewById<TextView>(Resource.Id.txtDrinkTitle);
            txtRecipe = view.FindViewById<TextView>(Resource.Id.txtRecipe);

            txtDrinkTitle.Text = drink.Name;
            txtRecipe.TextFormatted = Html.FromHtml(drink.Recipe);

            return view;
        }
    }
}