using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using BWS.Settings;
using BWS.Clients;

namespace BWS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(NewClientPage), typeof(NewClientPage));
            Routing.RegisterRoute(nameof(ClientDetailPage), typeof(ClientDetailPage));
            Routing.RegisterRoute(nameof(BWSDayPage), typeof(BWSDayPage));
            Routing.RegisterRoute(nameof(NewBWSDayPage), typeof(NewBWSDayPage));
            Routing.RegisterRoute(nameof(EditClientDetailPage), typeof(EditClientDetailPage));
        }

        public ICommand SettingsCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("SettingsPage");
        });

        public ICommand HelpCommand => new Command(async () =>
        {
            var uri = "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        });
    }
}
