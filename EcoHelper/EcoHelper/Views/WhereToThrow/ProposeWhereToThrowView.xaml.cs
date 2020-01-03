using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.WhereToThrow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProposeWhereToThrowView : ContentPage
    {
        private const string URL = "https://eco-helper.azurewebsites.net/api/Suggestion/create";
        private HttpClient _client = new HttpClient();
        public ProposeWhereToThrowView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DumpsterEntry.Text) && !string.IsNullOrWhiteSpace(GarbageEntry.Text))
            {
                var post = new Suggestion { dumpster = DumpsterEntry.Text, garbage = GarbageEntry.Text };
                var content = JsonConvert.SerializeObject(post);
                var result = await _client.PostAsync(URL, new StringContent(content, Encoding.UTF8, "application/json"));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Dziękuję!", "Twoja propozycja została wysłana.", "Ok");
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd", "Wystąpił błąd. Sprawdź połączenie internetowe.", "Ok");
                    });
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Błąd", "Uzupełnij dane", "Ok");
                });
            }
        }
    }

    public class Suggestion
    {
        public string dumpster { get; set; }
        public string garbage { get; set; }
    }
}