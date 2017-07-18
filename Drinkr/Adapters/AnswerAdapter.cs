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

namespace Drinkr.Adapters
{
    class AnswerAdapter : BaseAdapter
    {
        public List<string> answers;

        Context context;

        public AnswerAdapter(Context context)
        {
            this.context = context;

            answers = new List<string>();
            answers.Add("Red");
            answers.Add("Yellow");
            answers.Add("Orange");
            answers.Add("Blue");
            answers.Add("I don't have a favorite color!");
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return answers[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            AnswerAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AnswerAdapterViewHolder;

            if (holder == null)
            {
                holder = new AnswerAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.ListviewAnswer, parent, false);
                holder.Answer = view.FindViewById<RadioButton>(Resource.Id.radioButton1);
                view.Tag = holder;
            }


            //fill in your items

            holder.Answer.Text = answers[position];

            

            return view;
        }

        public override int Count
        {
            get
            {
                return answers.Count;
            }
        }



        //public override string this[int position]
        //{
        //    get { return answers[position]; }
        //}

        public override bool IsEnabled(int position)
        {
            return true;
        }
    }

    class AnswerAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public RadioButton Answer { get; set; }
    }
}