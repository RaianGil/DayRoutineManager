using DayRoutineManager.Models;
using DayRoutineManager.TblModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recordatorios : ContentPage
    {
        public Recordatorios()
        {
            InitializeComponent();
            BindingContext = new AdminRecordatorio();
        }

        public async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var detailRecordatorio = args.Item as RecortadorioModel;
            if (detailRecordatorio == null) return;

            await Navigation.PushAsync(new RecordatorioDeteail(detailRecordatorio));
            lvRecordatorio.SelectedItem = null;
        }
    }
}