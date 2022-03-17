using DayRoutineManager.Models;
using DayRoutineManager.Service;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DayRoutineManager.TblModels
{
  public  class AdminDependiente : BaseViewModel /*Models.DependienteModel*/
  {
         //[PrimaryKey]
        public string AdminDependiente_id { get; set; }
        public string Nombre_dependiente { get; set; }
        public string codigo_dependiente {get ; set;}


        private DBFirebase services;
        public Command AddDependienteCommand { get; }

        private ObservableCollection<DependienteModel> _Dependiente = new ObservableCollection<DependienteModel>();
        public ObservableCollection<DependienteModel> dependientes
        {
            get { return _Dependiente; }
            set
            {
                _Dependiente = value;
                OnPropertyChanged(nameof(dependientes));
            }
        }

        public AdminDependiente()
        {
            services = new DBFirebase();
            dependientes = services.GetAdminDependientes();
            AddDependienteCommand = new Command(async () => await
            AddDependienteAsync(AdminDependiente_id, Nombre_dependiente, codigo_dependiente));
        }

        public async Task AddDependienteAsync(string admindependiente_id, string nombre_dependiente, string codigo_dependiente)
        {
            await services.AddDependiente(admindependiente_id, nombre_dependiente, codigo_dependiente);
        }
    }
}
