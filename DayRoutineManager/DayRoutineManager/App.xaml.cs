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
            conn.CreateTable<Dependiente>();
            conn.CreateTable<Recordatorio>();
            conn.CreateTable<AdminDependiente>();
            MainPage = new NavigationPage(new Views.Login());
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
        }

        private void Current_NotificationTapped(Plugin.LocalNotification.EventArgs.NotificationEventArgs e)
        {
            MainPage = new NavigationPage(new Views.Login());
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
