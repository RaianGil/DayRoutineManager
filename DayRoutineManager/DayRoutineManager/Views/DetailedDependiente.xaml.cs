using DayRoutineManager.Models;
using DayRoutineManager.Service;
using DayRoutineManager.TblModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DayRoutineManager.Views
{
    public partial class DetailedDependiente : ContentPage
    {
        DBFirebase services;
        public DetailedDependiente(DependienteModel dependiente)
        {
            InitializeComponent();
            BindingContext = dependiente;
            services = new DBFirebase();
        }
        
        public async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            await services.UpdateDependiente(nombreDependiente.Text, codigoDependiente.Text, idDependiente.Text);
            await Navigation.PushAsync(new Dashboard());
        }

        public async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await services.DeleteDependiente(idDependiente.Text, nombreDependiente.Text, codigoDependiente.Text);
            await Navigation.PushAsync(new Dashboard());
        }
    }
}