using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.TblModels
{
    class AdminDependiente : Models.DependienteModel
    {
        [PrimaryKey]
        public string AdminDependiente_id { get; set; }
        public string Nombre_dependiente { get; set; }
    }
}
