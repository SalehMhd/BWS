using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using BWS.Common;
using System.Collections.ObjectModel;

namespace BWS.Clients
{
    [QueryProperty(nameof(ClientName), nameof(ClientName))]
    public class ClientDetailViewModel : BaseViewModel
    {
        private string name;
        private string phone;
        private string email;
        private string clientName;

        private bool showDate;

        public ObservableCollection<BWSDay> Weeks { get; }
        public Command<BWSDay> BWSDayTappedCommand { get; }
        public Command NewsBWSdayCommand { get; }
        public ClientDetailViewModel()
        {
            Weeks = new ObservableCollection<BWSDay>();
            BWSDayTappedCommand = new Command<BWSDay>(OnBWSDaySelected);
            NewsBWSdayCommand = new Command(OnNewBWSDayClicked);
            ShowDate = false;
        }

        private async void OnBWSDaySelected(BWSDay day)
        {
            if (day == null)
                return;

            await Shell.Current
                .GoToAsync($"{nameof(BWSDayPage)}?{nameof(BWSDayViewModel.Name)}={day.Name}");

        }

        //private async void OnNewBWSDayClicked()
        private void OnNewBWSDayClicked()
        {
            ShowDate = true;
            //await Shell.Current
            //    .GoToAsync($"{nameof(NewBWSDayPage)}?{nameof(BWSDayViewModel.Name)}='new'", true);
        }

        public async void OnAppearingExecuted()
        {
            try
            {
                Weeks.Clear();

                var client = await Task.FromResult(FakeClientStore.DB.Clients.FirstOrDefault(c => c.Name == name));
                var weeks = await Task.FromResult(client.BWSWeeks);
                foreach (var item in weeks)
                {
                    Weeks.Add(item);
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

        public async void LoadClient(string name)
        {
            try
            {
                var client = await Task.FromResult(FakeClientStore.DB.Clients.FirstOrDefault(c => c.Name == name));

                Name = client.Name;
                Phone = client.PhoneNumber;
                Email = client.Email;

                IsBusy = true;

                try
                {
                    Weeks.Clear();

                    var weeks = await Task.FromResult(client.BWSWeeks);
                    foreach (var item in weeks)
                    {
                        Weeks.Add(item);
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
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load client");
            }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string ClientName
        {
            get => clientName;
            set
            {
                clientName = value;
                LoadClient(HttpUtility.UrlDecode(clientName));
            }
        }

        public bool ShowDate
        {
            get => showDate;
            set => SetProperty(ref showDate, value);
        }
    }
}
