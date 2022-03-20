using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    public class RecortadorioModel
    {
        public string codigo_dependiente { get; set; }
        public string Titulo_recordatorio { get; set; }
        public string Descripcion_recordatorio { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public string fecha_inicio_formated { get; set; }
    }
}
