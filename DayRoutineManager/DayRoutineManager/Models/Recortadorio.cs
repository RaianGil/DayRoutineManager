using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    class Recortadorio
    {
        public string id_recordatorio { get; set; }
        public string id_dependiente { get; set; }
        public string titulo_recordatorio { get; set; }
        public string descripcion_recordatorio { get; set; }
        public string tipo_recordatorio { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}
