using System;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DayRoutineManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnAgregarDep_Clicked(object sender, EventArgs e)
        {
            var popup = new Popups.popAgregarDependiente
            {
                CloseWhenBackgroundIsClicked = true
            };
            PopupNavigation.Instance.PushAsync(popup);
        }
    }
}