using DayRoutineManager.Models;
using DayRoutineManager.Service;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DayRoutineManager.TblModels
{
    class AdminRecordatorio : BaseViewModel /*Models.RecordatorioModel*/
    {
        public string Titulo_recordatorio { get; set; }
        public string Descripcion_recordatorio { get; set; }
        public DateTime Fecha_inicio { get; set; }

        private DBFirebase services;
        public Command addRecordatorioCommand { get; }

        private ObservableCollection<RecortadorioModel> _Recordatorio = new ObservableCollection<RecortadorioModel>();
        public ObservableCollection<RecortadorioModel> recordatorio
        {
            get { return _Recordatorio; }
            set
            {
                _Recordatorio = value;
                OnPropertyChanged(nameof(recordatorio));
            }
        }

        public AdminRecordatorio()
        {
            services = new DBFirebase();
            recordatorio = services.GetAdminRecordatorio();
            addRecordatorioCommand = new Command(async () => await
            AddRecordatorioAsync(Titulo_recordatorio, Descripcion_recordatorio, Fecha_inicio));
        }

        public async Task AddRecordatorioAsync(string titulo_recordatorio, string descripcion_recordatorio, DateTime fecha_inicio)
        {
            await services.AddRecordatorio(titulo_recordatorio, descripcion_recordatorio, fecha_inicio);
        }
    }
}
