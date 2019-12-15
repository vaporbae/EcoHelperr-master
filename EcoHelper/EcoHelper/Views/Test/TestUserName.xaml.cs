using EcoHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHelper.Views.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestUserName : ContentPage
    {
        UserDatabaseController dbUser;
        public TestUserName()
        {
            dbUser = new UserDatabaseController();

            InitializeComponent();
        }

        private void onStartTestClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameText.Text))
            {
                var user = dbUser.CreateUser(UsernameText.Text);
                Navigation.PushAsync(new TestQuestion(user));
            }
        }
    }
}