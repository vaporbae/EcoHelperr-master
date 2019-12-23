using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EcoHelper.Droid;
using EcoHelper;
using Plugin.Permissions;
using Android.Support.V4.App;
using Plugin.CurrentActivity;
using Permission = Android.Content.PM.Permission;
using Android;

namespace App1.Droid
{
    [Activity(Label = "EcoHelper", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = EcoHelper.Droid.Resource.Layout.Tabbar;
            ToolbarResource = EcoHelper.Droid.Resource.Layout.Toolbar;
            
            base.OnCreate(savedInstanceState);

            CrossCurrentActivity.Current.Activity = this;
            int ACCESS_FINE_LOCATION = 0;
            ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessFineLocation },
                    ACCESS_FINE_LOCATION);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}