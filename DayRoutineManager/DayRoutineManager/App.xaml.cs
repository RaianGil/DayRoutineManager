using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var conn = Connection.LocalConn.get();
            conn.CreateTable<TblModels.Dependiente>();
            conn.CreateTable<TblModels.Recordatorio>();
            conn.CreateTable<TblModels.AdminDependiente>();
            // MainPage = new NavigationPage(new Views.DependienteDashboard());
            // MainPage = new Login();
            // MainPage = new Dashboard();
            // MainPage = new DependentInformation();
            MainPage = new NavigationPage(new Views.Dashboard());
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
