using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using EcoHelper.Models.Map;
using EcoHelper.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EcoHelper.ViewModels
{
    public class PharmaciesAddressViewModel : INotifyPropertyChanged
    {
        public const string GooglePlacesApiAutoCompletePath = "https://maps.googleapis.com/maps/api/place/autocomplete/json?key={0}&input={1}&components=country:pl"; //Adding country:us limits results to us

        public const string GooglePlacesApiKey = "AIzaSyCQiT46CiZjQ0--Du0ntSS5fZh52Its_o4";
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public PharmaciesAddressViewModel()
        {
            //GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
            //GetPlaceDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
        }


        private static HttpClient _httpClientInstance;
        public static HttpClient HttpClientInstance => _httpClientInstance ?? (_httpClientInstance = new HttpClient());
        private List<AddressInfo> addresses = new List<AddressInfo>();
        private List<AddressInfo> results = new List<AddressInfo>();

        private ObservableCollection<AddressInfo> _addresses;
        public ObservableCollection<AddressInfo> Addresses
        {
            get => _addresses ?? (_addresses = new ObservableCollection<AddressInfo>());
            set
            {
                if (_addresses != value)
                {
                    _addresses = value;
                    OnPropertyChanged("Addresses");
                }
            }
        }

        private string _addressText;
        public string AddressText
        {
            get => _addressText;
            set
            {
                if (_addressText != value)
                {
                    _addressText = value;
                    OnPropertyChanged("Addresses");
                }
            }
        }

        public async Task<List<AddressInfo>> GetPlacesPredictionsAsync(string addressText, string searchedTerm, string latlng)
        {
            // TODO: Add throttle logic, Google begins denying requests if too many are made in a short amount of time

            CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2)).Token;
            var address = WebUtility.UrlEncode(addressText).ToString();
            var url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?key=" + GooglePlacesApiKey + "&input=" + address + "&components=country:pl";
            var url2 = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + searchedTerm + "&location=" + latlng + "&radius=10000&key=" + GooglePlacesApiKey;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, searchedTerm.Length > 0 ? url2 : url))
            { //Be sure to UrlEncode the search term they enter

                using (HttpResponseMessage message = await HttpClientInstance.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false))
                {
                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (searchedTerm.Length > 0)
                        {
                            PlacesResultsList resultsList = await Task.Run(() => JsonConvert.DeserializeObject<PlacesResultsList>(json)).ConfigureAwait(false);
                            if (resultsList.Status == "OK")
                            {

                                results.Clear();

                                if (resultsList.Results.Count > 0)
                                {
                                    foreach (Results result in resultsList.Results)
                                    {
                                        results.Add(new AddressInfo
                                        {
                                            Address = result.FormattedAddress,
                                            PlaceId = result.PlaceId,
                                            Latitude = Convert.ToDouble(result.Geometry.Location.Lat),
                                            Longitude = Convert.ToDouble(result.Geometry.Location.Lng)
                                        });
                                    }
                                }
                                return results;
                            }
                            else
                            {
                                throw new Exception(resultsList.Status);
                            }
                        }

                        else
                        {
                            PlacesLocationPredictions predictionList = await Task.Run(() => JsonConvert.DeserializeObject<PlacesLocationPredictions>(json)).ConfigureAwait(false);

                            if (predictionList.Status == "OK")
                            {

                                addresses.Clear();

                                if (predictionList.Predictions.Count > 0)
                                {
                                    foreach (Prediction prediction in predictionList.Predictions)
                                    {
                                        addresses.Add(new AddressInfo
                                        {
                                            Address = prediction.Description,
                                            PlaceId = prediction.PlaceId
                                        });
                                    }
                                    OnPropertyChanged("Addresses");
                                }
                            }
                            else
                            {
                                throw new Exception(predictionList.Status);
                            }
                        }
                    }
                }
                return addresses;
            }
        }
    }
}
