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
        private ExerciseViewModel editedExercise = new ExerciseViewModel();
        private string selectedDayName;
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

        public ExerciseViewModel EditedExercise
        {
            get => editedExercise;
            set => SetProperty(ref editedExercise, value);
        }

        public Command FillExerciseCommand { get; }
        public Command AddEmptyExerciseCommand { get; }
        public Command AddExerciseShowPopupCommand { get; }
        public Command AddExerciseClosePopupCommand { get; }
        public Command CancelExerciseClosePopupCommand { get; }
        public Command EditExerciseShowPopupCommand { get; }
        public ObservableCollection<BWSDayViewModel> Weeks { get; }
        public EditClientDetailViewModel()
        {
            Weeks = new ObservableCollection<BWSDayViewModel>();
            FillExerciseCommand = new Command<BWSDayViewModel>(OnFillExerciseSelected);
            AddEmptyExerciseCommand = new Command<BWSDayViewModel>(OnAddEmptyExerciseSelected);
            AddExerciseShowPopupCommand = new Command<BWSDayViewModel>(OnAddExerciseShowPopupCommand);

            AddExerciseClosePopupCommand = new Command(OnAddExerciseClosePopupCommand);
            CancelExerciseClosePopupCommand = new Command(OnCancelExerciseClosePopupCommand);
            EditExerciseShowPopupCommand = new Command<ExerciseViewModel>(OnEditExerciseShowPopupCommand);

            ShowDate = false;
        }
        private async void OnEditExerciseShowPopupCommand(ExerciseViewModel exerciseVM)
        {
            selectedDayName = exerciseVM.DayName;
            editedExercise.Order = exerciseVM.Order;
            editedExercise.Name = exerciseVM.Name;
            editedExercise.Reps = exerciseVM.Reps;
            editedExercise.CoachComment = exerciseVM.CoachComment;

            var popupUpPage = new ExercisePage();
            popupUpPage.BindingContext = this;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupUpPage);

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
        
        private async void OnAddExerciseClosePopupCommand()
        {
            var selectedDay = Weeks.FirstOrDefault(d => d.Name == selectedDayName);
            if (editedExercise.Order == 1)
            {
                //selectedDay.Exercise1 = editedExercise;
                selectedDay.Exercise1.Name = editedExercise.Name;
                selectedDay.Exercise1.Reps = editedExercise.Reps;
                selectedDay.Exercise1.CoachComment = editedExercise.CoachComment;
                selectedDay.Exercise1.Order = editedExercise.Order;
                selectedDay.Exercise1.DayName = selectedDay.Name;
                selectedDay.Exercise1.ShowButton = false;
                selectedDay.Exercise1.ShowInfo = true;
                selectedDay.Exercise1Visible = true;
            }

            if (editedExercise.Order == 2)
            {
                selectedDay.Exercise2.Name = editedExercise.Name;
                selectedDay.Exercise2.Reps = editedExercise.Reps;
                selectedDay.Exercise2.CoachComment = editedExercise.CoachComment;
                selectedDay.Exercise2.Order = editedExercise.Order;
                selectedDay.Exercise2.DayName = selectedDay.Name;
                selectedDay.Exercise2.ShowButton = false;
                selectedDay.Exercise2.ShowInfo = true;
                selectedDay.Exercise2Visible = true;
            }

            if (editedExercise.Order == 3)
            {
                selectedDay.Exercise3.Name = editedExercise.Name;
                selectedDay.Exercise3.Reps = editedExercise.Reps;
                selectedDay.Exercise3.CoachComment = editedExercise.CoachComment;
                selectedDay.Exercise3.Order = editedExercise.Order;
                selectedDay.Exercise3.DayName = selectedDay.Name;
                selectedDay.Exercise3.ShowButton = false;
                selectedDay.Exercise3.ShowInfo = true;
                selectedDay.Exercise3Visible = true;
            }

            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
        private async void OnCancelExerciseClosePopupCommand()
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private async void OnAddEmptyExerciseSelected(BWSDayViewModel day)
        {
            selectedDayName = day.Name;
            editedExercise.Order = 0;
            editedExercise.Name = "";
            editedExercise.Reps = "";
            editedExercise.CoachComment= "";

            var popupUpPage = new ExercisePage();
            popupUpPage.BindingContext = this;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupUpPage);
            //if (day == null)
            //    return;

            //if (!day.Exercise1Visible)
            //{
            //    day.Exercise1Visible = true;
            //    day.Exercise1 = new ExerciseViewModel();
            //    day.Exercise1.ShowButton = true;
            //    day.Exercise1.ShowInfo = false;
            //    return;
            //}
            //if (!day.Exercise2Visible)
            //{
            //    day.Exercise2Visible = true;
            //    day.Exercise2 = new ExerciseViewModel();
            //    day.Exercise2.ShowButton = true;
            //    day.Exercise2.ShowInfo = false;
            //    return;
            //}
            //if (!day.Exercise3Visible)
            //{
            //    day.Exercise3Visible = true;
            //    day.Exercise3 = new ExerciseViewModel();
            //    day.Exercise3.ShowButton = true;
            //    day.Exercise3.ShowInfo = false;
            //    return;
            //}
        }
        private async void OnAddExerciseShowPopupCommand(BWSDayViewModel day)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ExercisePage());
            //if (day == null)
            //    return;

            //if (!day.Exercise1Visible)
            //{
            //    day.Exercise1Visible = true;
            //    day.Exercise1 = new ExerciseViewModel();
            //    day.Exercise1.ShowButton = true;
            //    day.Exercise1.ShowInfo = false;
            //    return;
            //}
            //if (!day.Exercise2Visible)
            //{
            //    day.Exercise2Visible = true;
            //    day.Exercise2 = new ExerciseViewModel();
            //    day.Exercise2.ShowButton = true;
            //    day.Exercise2.ShowInfo = false;
            //    return;
            //}
            //if (!day.Exercise3Visible)
            //{
            //    day.Exercise3Visible = true;
            //    day.Exercise3 = new ExerciseViewModel();
            //    day.Exercise3.ShowButton = true;
            //    day.Exercise3.ShowInfo = false;
            //    return;
            //}
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
