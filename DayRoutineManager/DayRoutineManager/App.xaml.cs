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
            conn.CreateTable<Models.Recortadorio>();
            conn.CreateTable<Models.DependienteAdmin>();
            // MainPage = new NavigationPage(new Views.DependienteDashboard());
            // MainPage = new Login();
            // MainPage = new Dashboard();
            // MainPage = new DependentInformation();
            MainPage = new Views.demoPage();

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
