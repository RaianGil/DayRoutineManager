using DayRoutineManager.Models;
using DayRoutineManager.TblModels;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayRoutineManager.Service
{
   public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://notidemo-e3f9b-default-rtdb.firebaseio.com/");
        }
        public async void sendToken(string token)
        {
            var upPrueba = await getDevice();
            if (upPrueba != null)
                update(token, upPrueba);
            else
                insert(token);
        }
        public async void insert(string token)
        {
            var sendDependiente = new Dependiente
            {
                codigo_dependiente = CrossDeviceInfo.Current.Id,
                token_dependiente = token
            };
            await client
                .Child("Dependiente")
                .PostAsync(sendDependiente);
        }
        public async void update(string token, FirebaseObject<Dependiente> inPrue)
        {
            Dependiente upPrueba = new Dependiente { codigo_dependiente = CrossDeviceInfo.Current.Id, token_dependiente = token };
            await client
                .Child("Dependiente")
                .Child(inPrue.Key)
                .PutAsync(upPrueba);
        }
        public async Task<FirebaseObject<Dependiente>> getDevice()
        {
            return (await client
               .Child("Dependiente")
               .OnceAsync<Dependiente>()).FirstOrDefault(a => a.Object.codigo_dependiente == CrossDeviceInfo.Current.Id);
        }
        /*Mantenimiento Dependiente*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /*Display Dependiente*/
        public ObservableCollection<DependienteModel> GetAdminDependientes()
        {
            var DependienteData = client
                .Child("AdminDependiente")
                .AsObservable<DependienteModel>()
                .AsObservableCollection();

            return DependienteData;
        }
        /*Agruegar Dependiente*/
        public async Task AddDependiente(string adminDependiente_id, string Nombre_dependiente, string codigo_dependiente)
        {
            DependienteModel dependiente = new DependienteModel()
               {AdminDependiente_id = adminDependiente_id,
                Nombre_dependiente = Nombre_dependiente,
                codigo_dependiente = codigo_dependiente};
                await client
                .Child("AdminDependiente")
                .PostAsync(dependiente);
        }
        /*Actualizar Dependiente*/
        public async Task UpdateDependiente(string Nombre_dependiente, string codigo_dependiente, string adminDependiente_id)
        {
            var updateDependiente = (await client
                .Child("AdminDependiente")
                .OnceAsync<DependienteModel>()).FirstOrDefault
                (a => a.Object.AdminDependiente_id == adminDependiente_id ||
                a.Object.Nombre_dependiente == Nombre_dependiente ||
                a.Object.codigo_dependiente == codigo_dependiente);

            DependienteModel admindep = new DependienteModel()
            { Nombre_dependiente = Nombre_dependiente, codigo_dependiente = codigo_dependiente, AdminDependiente_id = adminDependiente_id };
            await client
                .Child("AdminDependiente")
                .Child(updateDependiente.Key)
                .PutAsync(admindep);
        }
        /*Eliminar Dependiente*/
        public async Task DeleteDependiente(string adminDependiente_id, string Nombre_dependiente, string codigo_dependiente)
        {
            var deleteDependiente = (await client
                .Child("AdminDependiente")
                .OnceAsync<DependienteModel>()).FirstOrDefault
                (a => a.Object.AdminDependiente_id == adminDependiente_id ||
                a.Object.Nombre_dependiente == Nombre_dependiente ||
                a.Object.codigo_dependiente == codigo_dependiente);
            await client.Child("AdminDependiente").Child(deleteDependiente.Key).DeleteAsync();
        }
         /*Mantenimiento Recordatorio*////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /*Display Recordatorio*/
        public ObservableCollection<RecortadorioModel> GetAdminRecordatorio()
        {
            var RecordatorioData = client
                .Child("Recordatorio")
                .AsObservable<RecortadorioModel>()
                .AsObservableCollection();

            return RecordatorioData;
        }
        
        /*Agruegar Recordatorio*/
        public async Task AddRecordatorio(string titulo_recordatorio, string descripcion_recordatorio, DateTime fecha_inicio)
        {
            RecortadorioModel recordatorio = new RecortadorioModel()
            {
                 Titulo_recordatorio = titulo_recordatorio,
                Descripcion_recordatorio = descripcion_recordatorio,
                Fecha_inicio = fecha_inicio
            };
            
            await client
            .Child("Recordatorio")
            .PostAsync(recordatorio);
        }
        
        /*Actualizar Recordatorio*/
        public async Task UpdateRecordatorio(string titulo_recordatorio, string descripcion_recordatorio, DateTime fecha_inicio)
        {
            var updateRecordatorio = (await client
                .Child("Recordatorio")
                .OnceAsync<RecortadorioModel>()).FirstOrDefault
                (a => a.Object.Titulo_recordatorio == titulo_recordatorio ||
                a.Object.Descripcion_recordatorio == descripcion_recordatorio ||
                a.Object.Fecha_inicio == fecha_inicio);

            RecortadorioModel adminrecordatorio = new RecortadorioModel()
            { Titulo_recordatorio = titulo_recordatorio, Descripcion_recordatorio = descripcion_recordatorio, Fecha_inicio = fecha_inicio };
            await client
                .Child("Recordatorio")
                .Child(updateRecordatorio.Key)
                .PutAsync(adminrecordatorio);
        }
        
        /*Eliminar Recordatorio*/
        public async Task DeleteRecordatorio(string titulo_recordatorio, string descripcion_recordatorio, DateTime fecha_inicio)
        {
            var deleteRecordatorio = (await client
                .Child("Recordatorio")
                .OnceAsync<RecortadorioModel>()).FirstOrDefault
                (a => a.Object.Titulo_recordatorio == titulo_recordatorio ||
                a.Object.Descripcion_recordatorio == descripcion_recordatorio ||
                a.Object.Fecha_inicio == fecha_inicio);
            await client.Child("Recordatorio").Child(deleteRecordatorio.Key).DeleteAsync();
        }
    }
}
