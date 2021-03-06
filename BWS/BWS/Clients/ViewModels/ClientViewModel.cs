using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using BWS.Common;

namespace BWS.Clients
{
    public class ClientViewModel : Common.BaseViewModel
    {
        public ClientViewModel()
        {
            Clients = new ObservableCollection<Client>();
            LoadClientsCommand = new Command(async () => await ExecuteLoadClientsCommand());
            ClientTappedCommand = new Command<Client>(OnClientSelected);

            AddClientCommand = new Command(async ()=>
            {
                await Shell.Current.GoToAsync(nameof(NewClientPage));
            });
        }

        private bool _edit;
        public bool IsEdit {
            get => _edit;
            set => SetProperty(ref _edit, value);
        }

        private async Task ExecuteLoadClientsCommand()
        {
            IsBusy = true;

            try
            {
                Clients.Clear();

                var clients = await Task.FromResult(FakeClientStore.DB.Clients);
                foreach (var item in clients)
                {
                    Clients.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnClientSelected(Client client)
        {
            if (client == null)
                return;

            if(!IsEdit)
            { 
                await Shell.Current
                    .GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailViewModel.ClientName)}={client.Name}");
            }
            await Shell.Current
                .GoToAsync($"{nameof(EditClientDetailPage)}?{nameof(EditClientDetailViewModel.ClientName)}={client.Name}");


        }

        public ObservableCollection<Client> Clients { get; }
        public Command LoadClientsCommand { get; }
        public Command<Client> ClientTappedCommand { get; }
        public Command AddClientCommand { get; }
    }
}
