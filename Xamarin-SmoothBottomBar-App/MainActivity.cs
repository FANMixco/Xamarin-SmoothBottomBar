using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.Navigation;
using ME.Ibrahimsn.Lib;

namespace Xamarin_SmoothBottomBar_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private NavController NavController;
        SmoothBottomBar BottomBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);
                BottomBar = FindViewById<SmoothBottomBar>(Resource.Id.bottomBar);
                NavController = Navigation.FindNavController(this, Resource.Id.main_fragment);
            }
            catch (System.Exception ex)
            {

            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_bottom, menu);
            if (menu != null)
            {
                BottomBar.SetupWithNavController(menu, NavController);
            }

            return true;
        }

        public override bool OnSupportNavigateUp()
        {
            NavController.NavigateUp();
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}