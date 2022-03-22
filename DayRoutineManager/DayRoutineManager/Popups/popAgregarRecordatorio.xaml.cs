using DayRoutineManager.TblModels;
using DayRoutineManager.Views;
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
            BindingContext = new AdminRecordatorio();
        }

        public async void btnSend_Clicked(object sender, EventArgs e)
        {
            CloudAddedRecordatorio();
            addNotificationDependiente();
            await Navigation.PushAsync(new Dashboard());
        }


        public async void btnSendHoras_Clicked(object sender, EventArgs e)
        {
            CloudAddedRecordatorio();
            hourNotification();
            await Navigation.PushAsync(new Dashboard());
            if (HorasRecordatorio.Text == null)
            {
                await DisplayAlert("Alert", "Lapso/Horas campo requerido", "Ok");
            }
            return;
        }

        private async void btnSendDias_Clicked(object sender, EventArgs e)
        {
            CloudAddedRecordatorio();
            dailyNotification();
            await Navigation.PushAsync(new Dashboard());
            if (DiasRecordatorio.Text == null)
            {
                await DisplayAlert("Alert", "Lapso/Dias campo requerido", "Ok");
            }
            return;
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

        private void dailyNotification()
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
                    NotifyTime = DateTime.Parse(entHoraTarea.Text),
                    NotifyRepeatInterval = TimeSpan.FromDays(Int32.Parse(DiasRecordatorio.Text))
                }
            };
            NotificationCenter.Current.Show(notification);
        }

        private void hourNotification()
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
                    NotifyTime = DateTime.Parse(entHoraTarea.Text),
                    NotifyRepeatInterval = TimeSpan.FromHours(Int32.Parse(HorasRecordatorio.Text))
                }
            };
            NotificationCenter.Current.Show(notification);
        }

        private void CloudAddedRecordatorio()
        {
            firebaseClient.Child("Recordatorio").PostAsync(new Recordatorio
            {
                id_recordatorio = Guid.NewGuid().ToString(),
                Titulo_recordatorio = entTituloRecordatorio.Text,
                Descripcion_recordatorio = edDescripcionRecordatorio.Text,
                Fecha_inicio = DateTime.Parse(entHoraTarea.Text)
            });
        }

      
    }
}