using DayRoutineManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dependentDashboard : ContentPage
    {

        public dependentDashboard()
        {
            InitializeComponent();
            loadDependecies();
        }
        private void loadDependecies()
        {
            var conn = Connection.LocalConn.get();
            var listaTareas = new ObservableCollection<Recortadorio>();
            var getTareas = conn.Query<Recortadorio>("Select * From Recortadorio");
            foreach (var tarea in getTareas)
                listaTareas.Add(tarea);
            lvRecordatorios.ItemsSource = listaTareas;
        }
    }
}