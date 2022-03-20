using DayRoutineManager.Models;
using DayRoutineManager.Service;
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
        }

        public async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await services.DeleteRecordatorio(titulo_recordatorio.Text, descripcion_recordatorio.Text, DateTime.Parse(fecha_recordatorio.Text));
            await Navigation.PushAsync(new Recordatorios());
        }
    }
}