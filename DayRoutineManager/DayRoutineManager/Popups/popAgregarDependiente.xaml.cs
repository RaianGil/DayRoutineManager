using DayRoutineManager.Models;
using DayRoutineManager.TblModels;
using Firebase.Database;
using Firebase.Database.Query;
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
        FirebaseClient firebaseClient = new FirebaseClient("https://dailyroutinemanager-36ce7-default-rtdb.firebaseio.com/");
        public popAgregarDependiente()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            firebaseClient.Child("DependienteAdmin").PostAsync(new AdminDependiente
            {
                AdminDependiente_id = Guid.NewGuid().ToString(),
                codigo_dependiente = Codigotxt.Text,
                Nombre_dependiente = Nombretxt.Text
            });

            Codigotxt.Text = "";
            Nombretxt.Text = "";

           /* var conn = Connection.LocalConn.get();
            var insertDependiente = new AdminDependiente
            {               
                codigo_dependiente = Codigotxt.Text,
                Nombre_dependiente = Nombretxt.Text
            };
            conn.Insert(insertDependiente);*/
    
         }
     }
}