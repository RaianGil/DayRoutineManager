using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DayRoutineManager.TblModels
{
    class Recordatorio: Models.RecortadorioModel
    {
        [PrimaryKey]
        public string id_recordatorio { get; set; }
    }
}
