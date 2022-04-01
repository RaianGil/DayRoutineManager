using DayRoutineManager.TblModels;
using DayRoutineManager.Views;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.LocalNotification;
using Rg.Plugins.Popup.Services;
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
        FirebaseClient firebaseClient = new FirebaseClient("https://notidemo-e3f9b-default-rtdb.firebaseio.com/");
        public string codigo_dependiente;
        public popAgregarRecordatorio()
        {
            InitializeComponent();
            entHoraTarea.Text = DateTime.Now.ToString("MM/dd/yyy HH:mm");
            BindingContext = new AdminRecordatorio();
        }

        public async void btnSend_Clicked(object sender, EventArgs e)
        {
            if (HorasRecordatorio.Text != null)
            {
                hourNotification();
                addNotificationDependiente();
                CloudAddedRecordatorio();
            }
            else if (DiasRecordatorio.Text != null)
            {
                dailyNotification();
                addNotificationDependiente();
                CloudAddedRecordatorio();
            }
           else
            {
                CloudAddedRecordatorio();
                addNotificationDependiente();
            }

            await PopupNavigation.PopAsync();

        }

        private async void addNotificationDependiente()
        {
            if (entTituloRecordatorio.Text == null)
            {
                await DisplayAlert("Campo Obligatorio", "Titulo del recordatorio \nCAMPO REQUERIDO", "Ok");
            }
            else
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

        private async void dailyNotification()
        {
            double v;
            if (double.TryParse(DiasRecordatorio.Text, out v))
            {

                int Next = rdn.Next();
                Console.WriteLine(Next);
                var notification = new NotificationRequest
                {
                    BadgeNumber = 1,
                    Description = edDescripcionRecordatorio.Text,
                    Title = entTituloRecordatorio.Text,
                    NotificationId = Next,
                    Schedule =
                    {
                        NotifyTime = DateTime.Parse(entHoraTarea.Text),
                        NotifyRepeatInterval = TimeSpan.FromDays(double.Parse(DiasRecordatorio.Text))
                    }
                };
                NotificationCenter.Current.Show(notification);
            }

            else
            {
                await DisplayAlert("Datos incorrectos", "Ejemplo de Formato Correcto de datos: \n1.0 y 2.0", "Ok");
            }

        }

        private async void hourNotification()
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

        private async void CloudAddedRecordatorio()
        {
            if (entTituloRecordatorio == null)
            {
                entTituloRecordatorio.Focus();
            }
            else
            {
               await firebaseClient.Child("Recordatorio").PostAsync(new Recordatorio
                {
                    id_recordatorio = Guid.NewGuid().ToString(),
                    Titulo_recordatorio = entTituloRecordatorio.Text,
                    Descripcion_recordatorio = edDescripcionRecordatorio.Text,
                    Fecha_inicio = DateTime.Parse(entHoraTarea.Text)
                });
            }

        }

    }
}