using EcoHelper.Models.Map;
using EcoHelper.Models.Map.CustomPin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.DumpsterDetails.PharmacyPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PharmaciesMapPage : ContentPage
    {
        AddressInfo SelectedAddress;
        List<AddressInfo> Addresses;
        public PharmaciesMapPage(AddressInfo selectedAddress, List<AddressInfo> addresses)
        {

            InitializeComponent();
            SelectedAddress = selectedAddress;
            Addresses = addresses;
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(SelectedAddress.Latitude, SelectedAddress.Longitude), Distance.FromMiles(1)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(SelectedAddress.Latitude, SelectedAddress.Longitude),
                Label = "Tutaj jesteś",
                Address = SelectedAddress.Address
            };

            map.Pins.Add(pin);

            foreach(AddressInfo addressInfo in Addresses)
            {
                var pinn = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(addressInfo.Latitude, addressInfo.Longitude),
                    Label = "Apteka",
                    Address = addressInfo.Address
                };

                


                map.Pins.Add(pinn);
            }

            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
            //map.MapType = MapType.Street;

            Slider slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };
        }
    }
}