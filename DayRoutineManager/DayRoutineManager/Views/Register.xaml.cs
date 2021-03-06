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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        public async void btnRecordatorio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recordatorios());
        }

        public async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }
    }
}