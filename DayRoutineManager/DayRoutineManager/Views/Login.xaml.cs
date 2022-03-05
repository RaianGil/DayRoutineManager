using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
      

        public Login()
        {
            InitializeComponent();
        }

        private void btnJoinAdmin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Dashboard());
        }

        private void btnJoinDependiente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new dependentDashboard());
        }
    }
}