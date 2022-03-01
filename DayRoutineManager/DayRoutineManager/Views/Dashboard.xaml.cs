using System;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using DayRoutineManager.Models;

namespace DayRoutineManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            loadDependeiente();
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
            var listaTareas = new ObservableCollection<DependienteModel>();
            var getTareas = conn.Query<DependienteModel>("Select * From Dependiente");
            foreach (var tarea in getTareas)
            listaTareas.Add(tarea);
            lvDashboard.ItemsSource = listaTareas;
        }
    }
}