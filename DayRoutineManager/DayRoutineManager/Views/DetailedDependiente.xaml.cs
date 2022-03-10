using DayRoutineManager.Models;
using DayRoutineManager.Service;
using DayRoutineManager.TblModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedDependiente : ContentPage
    {
        DBFirebase services;
        DependienteModel dependiente = new DependienteModel();
        public DetailedDependiente()
        {
            InitializeComponent();
            BindingContext = dependiente;
            services = new DBFirebase();
                
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            await services.UpdateDependiente(nombreDependiente.Text, codigoDependiente.Text);
            await Navigation.PushAsync(new Dashboard());
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await services.DeleteDependiente(idDependiente.Text, nombreDependiente.Text, codigoDependiente.Text);
            await Navigation.PushAsync(new Dashboard());
        }
    }
}