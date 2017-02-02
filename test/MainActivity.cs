using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace test
{
    [Activity(Label = "test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate 
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    StringBuilder sb = new StringBuilder();
                    JsonWriter jw = new JsonTextWriter(new StringWriter(sb));
                    jw.WriteStartObject();
                    jw.WritePropertyName("id");
                    jw.WriteValue("1");
                    jw.WriteEndObject();

                    streamWriter.Write(sb.ToString());
                    streamWriter.Flush();
                };

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

            };
        }
    }
}

