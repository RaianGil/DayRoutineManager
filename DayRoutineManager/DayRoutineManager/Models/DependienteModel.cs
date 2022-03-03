using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    class DependienteModel
    {
        /* Parametros recibidos de la base de datos en xamarin*/            
        public string codigo_dependiente { get; set; }
        public string token_dependiente { get; set; }
    }
}
