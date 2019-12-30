using EcoHelper.Models.Map;
using EcoHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.DumpsterDetails.PSZOKPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PSZOKAddressPage : ContentPage
    {
        private const string ApiKey = "AIzaSyCQiT46CiZjQ0--Du0ntSS5fZh52Its_o4";
        PharmaciesAddressViewModel pAVM;
        AddressInfo SelectedAddress;
        List<AddressInfo> Addresses = new List<AddressInfo>();
        List<AddressInfo> Pszoks = new List<AddressInfo>();
        public PSZOKAddressPage()
        {
            InitializeComponent();
            pAVM = new PharmaciesAddressViewModel();
            AbsoluteLayout.IsVisible = false;

            AddressesList.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                SelectedAddress = ((AddressInfo)e.SelectedItem);
                AddressText.Text = SelectedAddress.Address;
                AbsoluteLayout.IsVisible = false;
            };
        }
        private async void OnTextChanged(object sender, EventArgs eventArgs)
        {
            AbsoluteLayout.IsVisible = true;
            if (!string.IsNullOrWhiteSpace(AddressText.Text) && AddressText.Text.Length > 2)
            {
                Addresses = await pAVM.GetPlacesPredictionsAsync(AddressText.Text, "", "");
                AddressesList.ItemsSource = null;
                AddressesList.ItemsSource = Addresses;
            }
            else
            {
                AddressesList.ItemsSource = null;
            }
        }



        private async void OnWrittenAddressGoToPharmaciesMapClick(object sender, EventArgs e)
        {
            //var addressInfo = await pAVM.GetPlaceLatLongAsync(SelectedAddress.PlaceId);
            //SelectedAddress.Latitude = addressInfo.Latitude;
            //SelectedAddress.Longitude = addressInfo.Longitude;
            SelectedAddress = await GetSelectedAddressLatLong(SelectedAddress);
            Pszoks = await pAVM.GetPlacesPredictionsAsync("", "pszok", SelectedAddress.Latitude.ToString() + "," + SelectedAddress.Longitude.ToString());

            await Navigation.PushAsync(new PSZOKMapPage(SelectedAddress, Pszoks));
        }

        private async void OnGetMyLatLngMapClick(object sender, EventArgs e)
        {
            SelectedAddress = new AddressInfo();
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    SelectedAddress.Latitude = location.Latitude;
                    SelectedAddress.Longitude = location.Longitude;
                    Pszoks = await pAVM.GetPlacesPredictionsAsync("", "pszok", SelectedAddress.Latitude.ToString() + "," + SelectedAddress.Longitude.ToString());
                    await Navigation.PushAsync(new PSZOKMapPage(SelectedAddress, Pszoks));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private async Task<AddressInfo> GetSelectedAddressLatLong(AddressInfo addressInfo)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(addressInfo.Address);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    addressInfo.Latitude = Convert.ToDouble(location.Latitude.ToString());
                    addressInfo.Longitude = Convert.ToDouble(location.Longitude.ToString());
                }
            }
            catch (FeatureNotSupportedException fnEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
            return addressInfo;
        }

        private async Task<List<AddressInfo>> GetPharmacies(string addressInfo)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(addressInfo);

                foreach (Xamarin.Essentials.Location location in locations)
                {
                    AddressInfo address = new AddressInfo();
                    address.Latitude = Convert.ToDouble(location.Latitude.ToString());
                    address.Longitude = Convert.ToDouble(location.Longitude.ToString());
                    Pszoks.Add(address);
                }
            }
            catch (FeatureNotSupportedException fnEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
            return Pszoks;
        }
    }
}