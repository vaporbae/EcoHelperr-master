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
using EcoHelper.Models;
using EcoHelper.Models.Map;
using EcoHelper.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EcoHelper.ViewModels
{
    public class WhereToThrowSearchViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public WhereToThrowSearchViewModel()
        {
        }
        //private List<AddressInfo> garbages = new List<AddressInfo>();
        //private List<AddressInfo> results = new List<AddressInfo>();

        //private ObservableCollection<AddressInfo> _addresses;
        //public ObservableCollection<Garbage> Garbages
        //{
        //    get => _addresses ?? (_addresses = new ObservableCollection<AddressInfo>());
        //    set
        //    {
        //        if (_addresses != value)
        //        {
        //            _addresses = value;
        //            OnPropertyChanged("Addresses");
        //        }
        //    }
        //}

        //public async Task<List<AddressInfo>> GetPlacesPredictionsAsync(string garbageText)
        //{

            
        //        return addresses;
        //}
    }
}
