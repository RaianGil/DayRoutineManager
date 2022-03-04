using DayRoutineManager.TblModels;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.LocalNotification;
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
    public partial class popAgregarRecordatorio
    {
        Random rdn = new Random();
        FirebaseClient firebaseClient = new FirebaseClient("https://dailyroutinemanager-36ce7-default-rtdb.firebaseio.com/");
        public string codigo_dependiente;
        public popAgregarRecordatorio()
        {
            InitializeComponent();
            entHoraTarea.Text = DateTime.Now.ToString("MM/dd/yyy HH:mm");
        }

        private void btnSend_Clicked(object sender, EventArgs e)
        {

            firebaseClient.Child("Recordatorio").PostAsync(new Recordatorio
            {
                id_recordatorio = Guid.NewGuid().ToString(),
                titulo_recordatorio = entTituloRecordatorio.Text,
                descripcion_recordatorio = edDescripcionRecordatorio.Text,
                codigo_dependiente = codigo_dependiente,
                fecha_inicio = DateTime.Parse(entHoraTarea.Text)
            });
            addNotificationDependiente();



            /* Console.WriteLine(codigo_dependiente);
             var conn = Connection.LocalConn.get();
             var inRecordatorio = new Recordatorio
             {
                 id_recordatorio = Guid.NewGuid().ToString(),
                 titulo_recordatorio = entTituloRecordatorio.Text,
                 descripcion_recordatorio = edDescripcionRecordatorio.Text,
                 codigo_dependiente = codigo_dependiente,
                 fecha_inicio = DateTime.Parse(entHoraTarea.Text)
             };
             conn.Insert(inRecordatorio);*/
        }

        private void addNotificationDependiente()
        {
            int Next = rdn.Next();
            Console.WriteLine(Next);
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = edDescripcionRecordatorio.Text,
                Title = entTituloRecordatorio.Text,
                ReturningData = "Datos añadidos exitosamente!",
                NotificationId = Next,
                Schedule =
                {
                    NotifyTime = DateTime.Parse(entHoraTarea.Text)
                }
            };
            NotificationCenter.Current.Show(notification);
        }
    }
}