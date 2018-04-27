using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using DeltaExam.Classes;

namespace DeltaExam
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        public double _latitude;
        public double _longitude;

		public MapPage (string latitude, string longitude)
		{
            _latitude  = (Convert.ToDouble(latitude));
            _longitude = (Convert.ToDouble(longitude));

            var map55 = new Xamarin.Forms.Maps.Map(
                        MapSpan.FromCenterAndRadius(
                                new Position(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var btn = new Button();
            btn.Text = "Save Favorite";
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map55);
            stack.Children.Add(btn);
            btn.Clicked += Btn_Clicked1; ; 
            Content = stack;
        }

        private void Btn_Clicked1(object sender, EventArgs e)
        {
            FavoriteLocations fave = new FavoriteLocations();
            fave.latitude  = _latitude;
            fave.longitude = _longitude;
            App.LocationRepo.SaveFavoriteLocation(fave);
            DisplayAlert("", "Favorite Saved", "OK");
        }
        
    }
}