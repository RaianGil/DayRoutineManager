using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    class Dependiente
    {
        /* Parametros recibidos de la base de datos en xamarin*/
        [PrimaryKey]
        public string id_dependiente { get; set; }
        public string codigo_dependiente { get; set; }

    }
}
