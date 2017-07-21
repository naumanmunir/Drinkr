using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Drinkr.Fragments;
using Android.Content;
using Android.App;
using Android.Support.V7.App;

namespace Drinkr.Adapters
{
    class DrinkRecyclerAdapter : RecyclerView.Adapter
    {
        string[] items;
        private Context Context { get; set; }

        public override int ItemCount => items.Length;

        public DrinkRecyclerAdapter(string[] data, Context context)
        {
            items = data;
            Context = context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewItem, parent, false);

            return new DrinkRecyclerAdapterViewHolder(itemView, Context);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as DrinkRecyclerAdapterViewHolder;
            holder.txtDrinkName.Text = items[position];
            //holder.btnDrink.Click += BtnDrink_Click;
        }

    }

    public class DrinkRecyclerAdapterViewHolder : RecyclerView.ViewHolder
    {
        private Context Context { get; set; }
        public TextView txtDrinkName { get; set; }
        public ImageButton btnDrink { get; set; }

        public DrinkRecyclerAdapterViewHolder(View itemView, Context context)  : base(itemView)
        {
            Context = context;
            txtDrinkName = itemView.FindViewById<TextView>(Resource.Id.txtDrinkName);
            btnDrink = itemView.FindViewById<ImageButton>(Resource.Id.imgDrink);

            btnDrink.Click += BtnDrink_Click;
        }

        private void BtnDrink_Click(object sender, EventArgs e)
        {
            DrinkDetailFragment ddf = new DrinkDetailFragment();

            Android.Support.V4.App.FragmentManager fm = ((AppCompatActivity)Context).SupportFragmentManager;

            Android.Support.V4.App.FragmentTransaction fragmentTransaction = fm.BeginTransaction();
            fragmentTransaction.Replace(Resource.Id.fragmentContainer, ddf);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

    }
}