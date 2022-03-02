using DayRoutineManager.Models;
using DayRoutineManager.TblModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class popAgregarDependiente
    {
        public popAgregarDependiente()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            var conn = Connection.LocalConn.get();
            var insertDependiente = new AdminDependiente
            {
                AdminDependiente_id = Guid.NewGuid().ToString(),
                codigo_dependiente = Codigotxt.Text,
                Nombre_dependiente = Nombretxt.Text
            };
            conn.Insert(insertDependiente);
    
         }
     }
}