using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayRoutineManager.Models
{
    class Dependiente
    {
        [PrimaryKey]
        public string id_dependiente { get; set; }
        public string codigo_dependiente { get; set; }

    }
}
