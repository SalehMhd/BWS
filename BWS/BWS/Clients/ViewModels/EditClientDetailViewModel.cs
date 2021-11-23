using BWS.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace BWS.Clients
{
    [QueryProperty(nameof(ClientName), nameof(ClientName))]
    class EditClientDetailViewModel : BaseViewModel
    {
        private string name;
        private string phone;
        private string email;
        private string clientName;

        private bool showDate;
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

        public Command FillExerciseCommand { get; }
        public Command AddEmptyExerciseCommand { get; }
        public ObservableCollection<BWSDayViewModel> Weeks { get; }
        public EditClientDetailViewModel()
        {
            Weeks = new ObservableCollection<BWSDayViewModel>();
            FillExerciseCommand = new Command<BWSDayViewModel>(OnFillExerciseSelected);
            AddEmptyExerciseCommand = new Command<BWSDayViewModel>(OnAddEmptyExerciseSelected);
            ShowDate = false;
        }
        private void OnFillExerciseSelected(BWSDayViewModel day)
        {
            if(day.Exercise1.ShowButton)
            {
                //Fill the view corresponding to the empty nect exercise
                day.Exercise1.Name = "SN";
                day.Exercise1.Reps = "654 654";
                day.Exercise1.ShowButton = false;
                day.Exercise1.ShowInfo = true;
                return;
            }
            if (day.Exercise2.ShowButton)
            {
                day.Exercise2.Name = "CJ";
                day.Exercise2.Reps = "84 56";
                day.Exercise2.ShowButton = false;
                day.Exercise2.ShowInfo = true;
                return;
            }
            if (day.Exercise3.ShowButton)
            {
                day.Exercise3.Name = "SQ";
                day.Exercise3.Reps = "48 61";
                day.Exercise3.ShowButton = false;
                day.Exercise3.ShowInfo = true;
                return;
            }
        }
        private void OnAddEmptyExerciseSelected(BWSDayViewModel day)
        {
            if (day == null)
                return;

            if (!day.Exercise1Visible)
            {
                day.Exercise1Visible = true;
                day.Exercise1 = new ExerciseViewModel();
                day.Exercise1.ShowButton = true;
                day.Exercise1.ShowInfo = false;
                return;
            }
            if (!day.Exercise2Visible)
            {
                day.Exercise2Visible = true;
                day.Exercise2 = new ExerciseViewModel();
                day.Exercise2.ShowButton = true;
                day.Exercise2.ShowInfo = false;
                return;
            }
            if (!day.Exercise3Visible)
            {
                day.Exercise3Visible = true;
                day.Exercise3 = new ExerciseViewModel();
                day.Exercise3.ShowButton = true;
                day.Exercise3.ShowInfo = false;
                return;
            }
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
                        Weeks.Add(BWSDayViewModel.CreateBWSDayViewModel(item));
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
    }
}
