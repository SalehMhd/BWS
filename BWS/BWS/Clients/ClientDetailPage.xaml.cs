using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BWS.Clients
{
    public partial class ClientDetailPage : ContentPage
    {
        public ClientDetailPage()
        {
            InitializeComponent();

            BindingContext = new ClientDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ClientDetailViewModel).OnAppearingExecuted();
        }
    }
}
