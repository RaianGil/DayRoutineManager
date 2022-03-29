using DayRoutineManager.Models;
using DayRoutineManager.Service;
using DayRoutineManager.TblModels;
using DayRoutineManager.Views;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.LocalNotification;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popAgregarDependiente : PopupPage
    {      
        FirebaseClient firebaseClient = new FirebaseClient("https://dailyroutinemanager-36ce7-default-rtdb.firebaseio.com/");
        public popAgregarDependiente()
        {
            InitializeComponent();
            BindingContext = new AdminDependiente();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (Nombretxt.Text == null)
            {
                await DisplayAlert("Alert", "Nombre \nCAMPO REQUERIDO", "Ok");
            }
            else
            {
                Codigotxt.Text = "";
                Nombretxt.Text = "";
            }

            await Navigation.PushAsync(new Dashboard());
            
        }


        private void LocaladdDependiente()
        {
            var conn = Connection.LocalConn.get();
            var insertDependiente = new AdminDependiente
            {
                AdminDependiente_id = Guid.NewGuid().ToString(),
                codigo_dependiente = Codigotxt.Text,
                Nombre_dependiente = Nombretxt.Text
            };
            conn.Insert(insertDependiente);
        }

     }
}