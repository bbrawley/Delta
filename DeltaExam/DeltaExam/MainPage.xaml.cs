using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using DeltaExam.ViewModels;

namespace DeltaExam
{
	public partial class MainPage : ContentPage
	{
        string latitude;
        string longitude;

        public MainPage()
		{
			InitializeComponent();
            GetUserPosition();
            BindingContext = new MainPageViewModel(Navigation);
            
        }

        /// <summary>
        /// Get a user's position from device.
        /// </summary>
        async void GetUserPosition()
        {
            var locator = CrossGeolocator.Current;
            Position userPosition = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            latitude  = userPosition.Latitude.ToString();
            longitude = userPosition.Longitude.ToString();

            Lat.Text = latitude.ToString();
            Long.Text = longitude.ToString();
       }

         
    }
}
