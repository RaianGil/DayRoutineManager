using DayRoutineManager.TblModels;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
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


        public async Task DeleteDependiente(string nombre, string codigo, string admindependiente_id)
        {
            var Clouddeletedependiente = (await client
                .Child("DependienteAdmin").OnceAsync<AdminDependiente>()).
                FirstOrDefault(a =>
                a.Object.Nombre_dependiente == nombre || a.Object.codigo_dependiente == codigo || a.Object.AdminDependiente_id == admindependiente_id);

            await client.Child("DependienteAdmin").Child(Clouddeletedependiente.Key).DeleteAsync();
        }

    }
}
