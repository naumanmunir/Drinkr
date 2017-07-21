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
using Android.Support.V7.Widget;
using Drinkr.Adapters;

namespace Drinkr.Fragments
{
    public class MoodFragment : Android.Support.V4.App.Fragment
    {
        RecyclerView DrinksRecyclerView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.MoodResult, container, false);

            LinearLayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);

            DrinksRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.DrinksRecyclerView);

            DrinksRecyclerView.SetLayoutManager(layoutManager);

            var items = new string[8];
            items[0] = "Pepsi";
            items[1] = "Coke";
            items[2] = "Chai Tea";
            items[3] = "Coolatta";
            items[4] = "Coffee";
            items[5] = "Red Bull";
            items[6] = "5 Hour Energy";
            items[7] = "Gatorade";

            DrinkRecyclerAdapter drv = new DrinkRecyclerAdapter(items, Context);
            DrinksRecyclerView.SetAdapter(drv);

            return view;
        }
    }
}