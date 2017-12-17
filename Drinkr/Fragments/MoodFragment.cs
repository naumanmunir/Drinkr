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
using Drinkr.Data;

using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using MikePhil.Charting.Util;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Animation;
using MikePhil.Charting.Components;

namespace Drinkr.Fragments
{
    public class MoodFragment : Android.Support.V4.App.Fragment
    {
        public static RestManager RestManager { get; private set; }
        List<string> AnswersSelected;
        RecyclerView DrinksRecyclerView;
        TextView currMood;

        private PieChart mChart;
        //private SeekBar mSeekBarX, mSeekBarY;
        private TextView tvX, tvY;

        public MoodFragment()
        {
        }

        public MoodFragment(List<string> answersSelected)
        {
            AnswersSelected = answersSelected;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RestManager = new RestManager(new RestService());

            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.MoodResult, container, false);

            LinearLayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            //currMood = view.FindViewById<TextView>(Resource.Id.txtMood);
            DrinksRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.DrinksRecyclerView);

            //tvX = (TextView)view.FindViewById(Resource.Id.tvXMax);
            //tvY = (TextView)view.FindViewById(Resource.Id.tvYMax);

            //mSeekBarX = (SeekBar)view.FindViewById(Resource.Id.seekBar1);
            //mSeekBarY = (SeekBar)view.FindViewById(Resource.Id.seekBar2);
            //mSeekBarX.SetProgress(4, true);
            //mSeekBarY.SetProgress(10, true);

            mChart = (PieChart)view.FindViewById(Resource.Id.chart);


            DrinksRecyclerView.SetLayoutManager(layoutManager);

            var moodResult = RestManager.GetCurrentMoods(AnswersSelected).Result;

            SetupPieChart(mChart, moodResult);

            var mood = moodResult.Max();

            //currMood.Text = mood;

            var drinksList = RestManager.GetDrinks(mood).Result;

            DrinkRecyclerAdapter drv = new DrinkRecyclerAdapter(drinksList, Context);
            DrinksRecyclerView.SetAdapter(drv);

            return view;
        }

        private void SetupPieChart(PieChart mChart, List<string> data)
        {
            mChart.SetUsePercentValues(true);
            mChart.Description.Enabled = false;
            mChart.Legend.Enabled = false;
            mChart.SetExtraOffsets(5, 10, 5, 5);

            mChart.DragDecelerationFrictionCoef = 0.95f;

            mChart.SetCenterTextTypeface(Android.Graphics.Typeface.Default);

            //mChart.setCenterText(generateCenterSpannableText());

            mChart.DrawHoleEnabled = true;
            mChart.SetHoleColor(Android.Graphics.Color.Transparent);

            mChart.SetTransparentCircleColor(Android.Graphics.Color.White);
            mChart.SetTransparentCircleAlpha(110);

            mChart.HoleRadius = 56f;
            mChart.TransparentCircleRadius = 61f;

            mChart.SetDrawCenterText(true);

            mChart.RotationAngle = 0;
            // enable rotation of the chart by touch
            mChart.RotationEnabled = true;
            mChart.HighlightPerTapEnabled = true;

            SetData(data);

            mChart.AnimateY(1400, Easing.EasingOption.EaseInOutQuad);

            //mChart.

            //Legend l = mChart.Legend;
            //l.VerticalAlignment = Legend.LegendVerticalAlignment.Top;
            //l.HorizontalAlignment = Legend.LegendHorizontalAlignment.Right;
            //l.Orientation = Legend.LegendOrientation.Vertical;
            //l.SetDrawInside(false);
            //l.XEntrySpace = 7f;
            //l.YEntrySpace = 0f;
            //l.YOffset = 0f;

            // entry label styling
            mChart.SetEntryLabelColor(Android.Graphics.Color.DarkSlateGray);
            //mChart.SetEntryLabelTypeface(mTfRegular);
            mChart.SetEntryLabelTextSize(11f);
            //mChart.
        }

        private void SetData(List<string> entry)
        {
            List<PieEntry> entries = new List<PieEntry>();

            entry.RemoveAll(i => i == null);

            var g = entry.GroupBy(i => i);

            // NOTE: The order of the entries when being added to the entries array determines their position around the center of
            // the chart.
            foreach (var item in g)
            {
                entries.Add(new PieEntry(item.Count(), item.Key));
            }

            PieDataSet dataSet = new PieDataSet(entries, "");

            
            //dataSet.SetDrawIcons(false);

            //dataSet.SliceSpace = 3f;
            //dataSet.IconsOffset = new MikePhil.Charting.Util.MPPointF(0, 40);
            //dataSet.SelectionShift = 5f;

            // add a lot of colors

            List<int> colors = new List<int>();

            foreach (int c in ColorTemplate.VordiplomColors)
                colors.Add(c);

            foreach (int c in ColorTemplate.JoyfulColors)
                colors.Add(c);

            foreach (int c in ColorTemplate.ColorfulColors)
                colors.Add(c);

            foreach (int c in ColorTemplate.LibertyColors)
                colors.Add(c);

            foreach (int c in ColorTemplate.PastelColors)
                colors.Add(c);

            colors.Add(ColorTemplate.HoloBlue);

            dataSet.SetColors(colors.ToArray());
            //dataSet.setSelectionShift(0f);

            PieData data = new PieData(dataSet);
            data.SetValueFormatter(new PercentFormatter());
            data.SetValueTextSize(14f);
            data.SetValueTextColor(Android.Graphics.Color.DarkSlateGray);
            //data.SetValueTypeface(mTfLight);
            mChart.Data = data;

            // undo all highlights
            mChart.HighlightValues(null);

            mChart.Invalidate();
        }
    }
}