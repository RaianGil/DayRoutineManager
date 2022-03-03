using Plugin.DeviceInfo;
using System;
using DayRoutineManager.TblModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using Xamarin.Essentials;

namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DependienteDashboard : ContentPage
    {
        string id_device = CrossDeviceInfo.Current.Id;
        SQLite.SQLiteConnection conn = Connection.LocalConn.get();

        public DependienteDashboard()
        {
            InitializeComponent();
            loginDependiente();
            loadTasks();
        }

        private void loginDependiente()
        {
            //var checkExist = conn.Query<Dependiente>($"select * from dependiente where codigo_dependiente = '{id_device}'");
            //if (!checkExist.Any())
            //    Preferences.Set("ID_DEPENDIENTE", checkExist.First().id_dependiente);
            //else
            //{
            //    string strIDDependiente = Guid.NewGuid().ToString();
            //    var inDependiente = new Dependiente
            //    {
            //        id_dependiente = Guid.NewGuid().ToString(),
            //        codigo_dependiente = id_device,
            //    };
            //    conn.Insert(inDependiente);
            //    Preferences.Set("ID_DEPENDIENTE", strIDDependiente);
            //}

        }

        private void loadTasks()
        {
            var listRecordatorio = new ObservableCollection<Recordatorio>();
            var getRecordatorio = conn.Query<Recordatorio>($"select * from recordatorio where id_dependiente = '{Preferences.Get("ID_DEPENDIENTE","")}'");
            if (getRecordatorio.Any())
            {
                foreach (var Recordatorio in getRecordatorio)
                    listRecordatorio.Add(Recordatorio);
            }
        }
    }
}