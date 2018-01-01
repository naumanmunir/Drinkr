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
using Android.Graphics;
using Android.Graphics.Drawables;
using System.IO;

namespace Drinkr.Fragments
{
    public class AdminFragment : Android.Support.V4.App.Fragment
    {
        Spinner spin;
        Button btnAdd;
        EditText txtName;
        EditText txtDesc;
        Button btnAddImage;
        ImageView imgUpload;

        public static readonly int PickImageId = 1000;
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
            btnAddImage = view.FindViewById<Button>(Resource.Id.btnAddImage);
            txtName = view.FindViewById<EditText>(Resource.Id.editTxtDrinkName);
            txtDesc = view.FindViewById<EditText>(Resource.Id.editTxtDesc);
            imgUpload = view.FindViewById<ImageView>(Resource.Id.imgUpload);

            btnAddImage.Click += BtnAddImage_Click;
            btnAdd.Click += BtnAdd_Click;
            spin.ItemSelected += Spin_ItemSelected;

            var adapter = ArrayAdapter.CreateFromResource(Context, Resource.Array.moodID, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spin.Adapter = adapter;

            return view;
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var moodID = spin.SelectedItem.ToString();
            var drinkName = txtName.Text;
            var drinkDesc = txtDesc.Text;

            Bitmap bm = ((BitmapDrawable)imgUpload.Drawable).Bitmap;
            
            MemoryStream ms = new MemoryStream();
            bm.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);

            var data = ms.ToArray();
            //var uploadContent = Convert.ToBase64String(data);
            RestManager.AddDrink(drinkName, moodID, drinkDesc, data);

            
            txtName.Text = string.Empty;
            txtDesc.Text = string.Empty;

        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            
            if ((requestCode == PickImageId) && (resultCode == Convert.ToInt32(Result.Ok)) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                imgUpload.SetImageURI(uri);
            }
        }

        private void Spin_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
        }
    }
}