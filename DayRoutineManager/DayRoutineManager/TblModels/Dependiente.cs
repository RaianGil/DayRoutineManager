using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DayRoutineManager.TblModels
{
    class Dependiente: Models.DependienteModel
    {
       [PrimaryKey]
       public string id_dependiente { get; set; }
    }
}
