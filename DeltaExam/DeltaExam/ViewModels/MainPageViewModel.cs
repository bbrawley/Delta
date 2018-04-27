using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DeltaExam.ViewModels
{
    public class MainPageViewModel
    {

        public INavigation Navigation { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICommand MapPageCommand => new Command(async () => await gotoMapPage());
        async Task gotoMapPage()
        {
            await Navigation.PushAsync(new MapPage(Latitude, Longitude));
        }
    }
}
