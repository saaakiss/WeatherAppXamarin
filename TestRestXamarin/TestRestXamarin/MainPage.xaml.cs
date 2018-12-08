using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestXamarin.Models;
using Xamarin.Forms;

namespace TestRestXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void View_Weather_Button(object sender, EventArgs e)
        {
            string selectedCity = EntryCity.Text;
            selectedCity = selectedCity.Trim();
            if(selectedCity != "" && selectedCity != null)
            {
                Navigation.PushAsync(new JsonParsingPage(selectedCity));
            }
            else
            {
                DisplayAlert("Error", "Type a city", "OK");
            }
        }
    }
}
