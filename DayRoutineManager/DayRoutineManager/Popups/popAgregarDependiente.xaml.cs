using DayRoutineManager.Models;
using DayRoutineManager.Service;
using DayRoutineManager.TblModels;
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
        DBFirebase services;
        public popAgregarDependiente()
        {
            InitializeComponent();
            BindingContext = new AdminDependiente();
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            // CloudaddDependiente();
           // LocaladdDependiente();
            Codigotxt.Text = "";
            Nombretxt.Text = "";
            //addNotificationDependiente();
           
        }

        private void CloudaddDependiente()
        {
            firebaseClient.Child("DependienteAdmin").PostAsync(new AdminDependiente
            {
                AdminDependiente_id = Guid.NewGuid().ToString()
                //codigo_dependiente = Codigotxt.Text,
              //  Nombre_dependiente = Nombretxt.Text
            });

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

        private void addNotificationDependiente()
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Datos añadidos exitosamente!",
                Title = "Datos Actualizados",
                ReturningData = "Datos añadidos exitosamente!",
                NotificationId = 111,
                Schedule =
                {
                    NotifyTime = DateTime.Parse("03/04/2022 12:30")
                }
            };
             NotificationCenter.Current.Show(notification);
        }
     }
}