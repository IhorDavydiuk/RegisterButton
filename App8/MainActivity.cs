using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.Connectivity;
using System.Linq;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Plugin.Connectivity.Abstractions;

namespace App8
{
    [Activity(Label = "App8", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Android.Widget.Button button1;
        TextView textView1;
        TextView textView2;
        TextView textView3;
        HttpClient httpClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Main);

            httpClient = new HttpClient();
            button1 = FindViewById<Android.Widget.Button>(Resource.Id.button1);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView1.Text = CrossConnectivity.Current.IsConnected.ToString();
            textView2.Text = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString();

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            button1.Click += delegate (object sender, EventArgs e)
            {
                DateTime PushButtonTime = DateTime.Now;
                var button = new { PushButtonTime };
                textView3.Text = PushButtonTime.ToString();
                string json = JsonConvert.SerializeObject(button);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpClient.PostAsync("http://192.168.0.101:53538/api/values", httpContent);
            };
        }
        private void CheckConnection()
        {
            textView1.SetCursorVisible(!CrossConnectivity.Current.IsConnected);
            textView2.SetCursorVisible(CrossConnectivity.Current.IsConnected);

            if (CrossConnectivity.Current != null &&
                CrossConnectivity.Current.ConnectionTypes != null &&
                CrossConnectivity.Current.IsConnected == true)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                textView2.Text = connectionType.ToString();
            }
        }
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            textView1.Text = CrossConnectivity.Current.IsConnected.ToString();
            textView2.Text = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault().ToString();
        }
    }
}

