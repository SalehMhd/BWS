using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace BWS.Clients
{
    public partial class NewClientPage : ContentPage
    {
        public NewClientPage()
        {
            InitializeComponent();

            BindingContext = new NewClientViewModel();
        }
           
    }
}
