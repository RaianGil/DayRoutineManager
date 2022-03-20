using DayRoutineManager.TblModels;
using Firebase.Database;
using Plugin.FirebasePushNotification;
using Plugin.LocalNotification;
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
           /* conn.CreateTable<TblModels.Dependiente>();
            conn.CreateTable<TblModels.Recordatorio>();
            conn.CreateTable<TblModels.AdminDependiente>();*/
            MainPage = new NavigationPage(new Views.Register());
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
        }

        private void Current_NotificationTapped(Plugin.LocalNotification.EventArgs.NotificationEventArgs e)
        {
             MainPage = new NavigationPage(new Views.dependentDashboard());        
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
            var sendToken = new Service.DBFirebase();
            sendToken.sendToken(e.Token);
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
