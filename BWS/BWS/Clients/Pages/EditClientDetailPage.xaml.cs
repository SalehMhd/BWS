using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BWS.Clients
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClientDetailPage : ContentPage
    {
        public EditClientDetailPage()
        {
            InitializeComponent();
            BindingContext = new EditClientDetailViewModel();
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            (BindingContext as EditClientDetailViewModel).Weeks.Add(new BWSDayViewModel
            {
                Name = args.NewDate.DayOfWeek.ToString(),
                Type = 0
            });
            datePicker.IsVisible = false;
        }

        private void AddDayButton_Clicked(object sender, EventArgs e)
        {
            datePicker.Focus();
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
    }
}