using Rg.Plugins.Popup.Services;
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
    public partial class demoPage : ContentPage
    {
        public demoPage()
        {
            InitializeComponent();
        }

        private void btnShowPop_Clicked(object sender, EventArgs e)
        {
            var popup = new Popups.Page1
            {
                CloseWhenBackgroundIsClicked = true
            };
            PopupNavigation.Instance.PushAsync(popup);
        }
    }
}