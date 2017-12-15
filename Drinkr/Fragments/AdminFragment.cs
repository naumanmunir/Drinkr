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

namespace Drinkr.Fragments
{
    public class AdminFragment : Android.Support.V4.App.Fragment
    {
        Spinner spin;
        Button btnAdd;
        EditText txtName;
        EditText txtDesc;

        public static RestManager RestManager { get; private set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Admin, container, false);

            RestManager = new RestManager(new RestService());

            spin = view.FindViewById<Spinner>(Resource.Id.spinner1);
            btnAdd = view.FindViewById<Button>(Resource.Id.btnAddDrink);
            txtName = view.FindViewById<EditText>(Resource.Id.editTxtDrinkName);
            txtDesc = view.FindViewById<EditText>(Resource.Id.editTxtDesc);

            btnAdd.Click += BtnAdd_Click;
            spin.ItemSelected += Spin_ItemSelected;

            var adapter = ArrayAdapter.CreateFromResource(Context, Resource.Array.moodID, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spin.Adapter = adapter;

            return view;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var moodID = spin.SelectedItem.ToString();
            var drinkName = txtName.Text;
            var drinkDesc = txtDesc.Text;

            RestManager.AddDrink(drinkName, moodID, drinkDesc);

         }

        private void Spin_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
        }
    }
}