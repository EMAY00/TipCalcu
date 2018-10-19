using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editBar;
        TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            textView = FindViewById<TextView>(Resource.Id.textView1);
            editBar = FindViewById<EditText>(Resource.Id.textInputEditText1);
            var seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);

            seekBar.ProgressChanged += SeekBar_ProgressChanged;
        }

        private void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            double amounttotal;
            if (editBar.Text.Contains(","))
            {
                amounttotal = double.Parse(editBar.Text.Replace(',', '.'));
            }
            else
            {
                amounttotal = double.Parse(editBar.Text);
            }
            int percent = e.Progress;
            FindViewById<TextView>(Resource.Id.textView3).Text = "Tip percent: " + percent + "%";
            double tipValue = (amounttotal * percent) / 100;
            FindViewById<TextView>(Resource.Id.textView5).Text = "Total:  " + Math.Round((amounttotal + tipValue), 2);
        }


    }
}