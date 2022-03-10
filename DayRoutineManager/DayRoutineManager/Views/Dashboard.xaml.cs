using System;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using DayRoutineManager.TblModels;
using Xamarin.Essentials;
using DayRoutineManager.Models;

namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            //loadDependeiente();
            // loadRecordatorio();
            BindingContext = new AdminDependiente();
        }

        private void BtnAgregarDep_Clicked(object sender, EventArgs e)
        {
                     
            var popup = new Popups.popAgregarDependiente
            {
                CloseWhenBackgroundIsClicked = true
            };
            PopupNavigation.Instance.PushAsync(popup);
        }

        private void loadDependeiente()
        {
            var conn = Connection.LocalConn.get();
            var listaDependiente = new ObservableCollection<AdminDependiente>();
            var getDependiente = conn.Query<AdminDependiente>("Select * From AdminDependiente");
            foreach (var tarea in getDependiente)
                listaDependiente.Add(tarea);
            lvDashboard.ItemsSource = listaDependiente;
        }

        private void btnAddRecordatorio_Clicked(object sender, EventArgs e)
        {
            var AddRecordatorio = (Button)sender;
            var popup = new Popups.popAgregarRecordatorio
            {
                CloseWhenBackgroundIsClicked = true,
                codigo_dependiente = AddRecordatorio.BindingContext.ToString()
            };
            PopupNavigation.Instance.PushAsync(popup);
        }

        private void loadRecordatorio()
        {
            var conn = Connection.LocalConn.get();
            var listaRecordatorio = new ObservableCollection<Recordatorio>();
            var getRecordatorio = conn.Query<Recordatorio>("Select * From Recordatorio");
            foreach (var tarea in getRecordatorio)
                listaRecordatorio.Add(tarea);
            lvDashboard.ItemsSource = listaRecordatorio;
        }

        private void BtnRecordatorios_Clicked(object sender, EventArgs e)
        {

        }

        public async void lvDashboard_ItemTapped(object sender, ItemTappedEventArgs args)
        {
            var detailDependiente = args.Item as DependienteModel;
            if (detailDependiente == null) return;

            await Navigation.PushAsync(new DetailedDependiente());
            lvDashboard.SelectedItem = null;
        }

    }
}