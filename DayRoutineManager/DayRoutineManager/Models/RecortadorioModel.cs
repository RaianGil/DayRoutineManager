using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    class RecortadorioModel
    {
        public string titulo_recordatorio { get; set; }
        public string descripcion_recordatorio { get; set; }
        public string tipo_recordatorio { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string fecha_inicio_formated { get; set; }
    }
}
