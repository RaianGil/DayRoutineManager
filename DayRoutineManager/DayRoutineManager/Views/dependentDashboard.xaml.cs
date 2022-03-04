using DayRoutineManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.DeviceInfo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dependentDashboard : ContentPage
    {
        
        
        public dependentDashboard()
        {
            InitializeComponent();
            loadDependecies();
            CodigoDependiente.Text = CrossDeviceInfo.Current.Id;
        }
        private void loadDependecies()
        {
            var conn = Connection.LocalConn.get();
            var listaTareas = new ObservableCollection<RecortadorioModel>();
            var getTareas = conn.Query<RecortadorioModel>("Select * From Recortadorio");
            foreach (var tarea in getTareas)
            listaTareas.Add(tarea);
            lvRecordatorios.ItemsSource = listaTareas;
        }
    }
}