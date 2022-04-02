using DayRoutineManager.Models;
using DayRoutineManager.Service;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Views
{
    public partial class RecordatorioDeteail : ContentPage
    {
        DBFirebase services;
        Random rdn = new Random();
        public string codigo_dependiente;
        public RecordatorioDeteail(RecortadorioModel recordatorio)
        {
            InitializeComponent();
            BindingContext = recordatorio;
            services = new DBFirebase();
        }

        public async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            await services.UpdateRecordatorio(titulo_recordatorio.Text, descripcion_recordatorio.Text, DateTime.Parse(fecha_recordatorio.Text));
            await Navigation.PushAsync(new Recordatorios());
            updateNotification();

        }

        public async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await services.DeleteRecordatorio(titulo_recordatorio.Text, descripcion_recordatorio.Text, DateTime.Parse(fecha_recordatorio.Text));
            await Navigation.PushAsync(new Recordatorios());
        }

        private async void updateNotification()
        {

            int Next = rdn.Next();
            Console.WriteLine(Next);
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = descripcion_recordatorio.Text,
                Title = titulo_recordatorio.Text,
                ReturningData = "Datos añadidos exitosamente!",
                NotificationId = Next,
                Schedule =
                    {
                        NotifyTime = DateTime.Parse(fecha_recordatorio.Text),
                    }
            };
            NotificationCenter.Current.Show(notification);

        }
    }
}