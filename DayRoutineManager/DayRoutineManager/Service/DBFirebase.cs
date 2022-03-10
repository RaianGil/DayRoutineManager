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
    class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://dailyroutinemanager-36ce7-default-rtdb.firebaseio.com/");
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

        public ObservableCollection<DependienteModel> GetAdminDependientes()
        {
            var DependienteData = client
                .Child("AdminDependiente")
                .AsObservable<DependienteModel>()
                .AsObservableCollection();

            return DependienteData;
        }

        public async Task AddDependiente(string adminDependiente_id, string Nombre_dependiente, string codigo_dependiente)
        {
            DependienteModel dependiente = new DependienteModel()
              { AdminDependiente_id = adminDependiente_id,
                Nombre_dependiente = Nombre_dependiente,
                codigo_dependiente = codigo_dependiente};
                 await client
                .Child("AdminDependiente")
                .PostAsync(dependiente);
        }

        public async Task UpdateDependiente(string Nombre_dependiente, string codigo_dependiente)
        {
            var updateDependiente = (await client
                .Child("AdminDependiente")
                .OnceAsync<AdminDependiente>()).FirstOrDefault
                (a => a.Object.Nombre_dependiente == Nombre_dependiente);

            AdminDependiente admindep = new AdminDependiente() 
            { Nombre_dependiente = Nombre_dependiente, codigo_dependiente = codigo_dependiente };
            await client
                .Child("AdminDependiente")
                .Child(updateDependiente.Key).PutAsync(admindep);

        }

        public async Task DeleteDependiente(string adminDependiente_id, string Nombre_dependiente, string codigo_dependiente)
        {
            var deleteDependiente = (await client
                .Child("AdminDependiente")
                .OnceAsync<AdminDependiente>()).FirstOrDefault
                (a => a.Object.AdminDependiente_id == adminDependiente_id ||
                a.Object.Nombre_dependiente == Nombre_dependiente ||
                a.Object.codigo_dependiente == codigo_dependiente);
            await client.Child("AdminDependiente").Child(deleteDependiente.Key).DeleteAsync();
        }

    }
}
