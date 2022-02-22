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
            conn.CreateTable<Models.Dependiente>();
            MainPage = new NavigationPage(new Views.DependienteDashboard());
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
