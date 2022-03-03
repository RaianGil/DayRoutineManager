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

namespace DayRoutineManager.Views
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
    }
}