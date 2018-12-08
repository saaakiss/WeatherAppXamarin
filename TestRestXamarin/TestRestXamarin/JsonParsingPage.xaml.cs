using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TestRestXamarin.Models.JsonWeather;

namespace TestRestXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonParsingPage : ContentPage
    {
        public JsonParsingPage(string selectedCity)
        {
            InitializeComponent();
            GetJSON(selectedCity);
        }

        public async void GetJSON(string selectedCity)
        {
            selectedCity = selectedCity.ToLower();


            // Check network status  
            if (NetworkCheck.IsInternet())
            {
                var client = new System.Net.Http.HttpClient(new NativeMessageHandler());
                var response = await client.GetAsync("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + selectedCity + ",gr&units=metric&APPID=95057c59e9f8847e4f0519623370d03d&cnt=7");
                string stringJson = await response.Content.ReadAsStringAsync(); //Getting response  

                RootObject rootObject = new RootObject();
                List<ListJs> listJson = new List<ListJs>();
                List<DateTimeClass> dateTime = new List<DateTimeClass>();

                if(stringJson != null && stringJson != "")
                {
                    rootObject = JsonConvert.DeserializeObject<RootObject>(stringJson);
                    string cityResponse = "Weather in " + rootObject.city.name.ToString();
                    TitleLabel.Text = cityResponse;

                    foreach(var m in rootObject.list)
                    {
                        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        long unixTimeStampInTicks = (long)(m.dt * TimeSpan.TicksPerSecond);
                        DateTime dt = new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
                        dateTime.Add(new DateTimeClass
                        {
                            Date = dt.Date.ToString()
                        });
                    }

                }

                var i = 0;
                var finalResponse = rootObject.list;
                foreach (var m in finalResponse)
                {
                    m.normDate = dateTime.ElementAt(i).Date.Substring(0, dateTime.ElementAt(i).Date.IndexOf(" ") + 1);
                    i++;
                }

                listViewWeather.ItemsSource = finalResponse;
            }
            else
            {
                await DisplayAlert("Error", "No network is available", "OK");
            }

            ProgressLoader.IsVisible = false;
        }
    }
}