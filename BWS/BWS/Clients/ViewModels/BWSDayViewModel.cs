using BWS.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace BWS.Clients
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class BWSDayViewModel : BaseViewModel
    {
        public Command NewExerciseCommand { get; }
        public Command SaveDayCommand { get; }

        public BWSDayViewModel()
        {
            NewExerciseCommand = new Command(OnNewExerciseSelected);
            SaveDayCommand = new Command(OnSaveDaySelected);
            Exercise1Visible = Exercise2Visible = Exercise3Visible = false;
        }

        private async void OnSaveDaySelected()
        {
            var tempName = Name;
            var exe1 = Exercise1;
            var exe2 = Exercise2;
            var exe3 = Exercise3;
            // the new day is added to object c but not to the faleClientStore
            var c = FakeClientStore.DB.Clients.FirstOrDefault(s => s.Name.Contains("Saleh"));
            c.BWSWeeks.Add(new BWSDay2
            {
                Name = tempName,
                Exercise1 = new Exercise { Name = exe1.Name, Reps = exe1.Reps, CoachComment = exe1.CoachComment } ,
                Exercise2 = new Exercise { Name = exe2.Name, Reps = exe2.Reps, CoachComment = exe2.CoachComment },
            });

            await Shell.Current.GoToAsync($"..?{nameof(ClientDetailViewModel.ClientName)}=Saleh Mohammad", true);
        }

        public async void LoadBWSDay(string name)
        {
            try
            {
                var day = await Task.FromResult(FakeClientStore.DB.Clients.FirstOrDefault(s => s.Name.Contains("Saleh")).BWSWeeks.FirstOrDefault(c => c.Name == name));
                if (name != "new")
                {
                    SetViewModelProperties(day);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Failed to Load BWSDay");
            }
        }

        internal static BWSDayViewModel CreateBWSDayViewModel(BWSDay item)
        {
            var day = new BWSDayViewModel();

            day.Name = item.Name;
            day.Type = item.Type;

            if(item.Type > 0)
            { 
                BWSDay1 dayType1 = (BWSDay1)item;
                day.Exercise1 = new ExerciseViewModel { Name = dayType1.Exercise1.Name, Reps = dayType1.Exercise1.Reps, CoachComment = dayType1.Exercise1.CoachComment };
            }
            if (item.Type > 1)
            {
                BWSDay2 dayType2 = (BWSDay2)item;
                day.Exercise2 = new ExerciseViewModel { Name = dayType2.Exercise2.Name, Reps = dayType2.Exercise2.Reps, CoachComment = dayType2.Exercise2.CoachComment };
            }
            if (item.Type > 2)
            {
                BWSDay3 dayType3 = (BWSDay3)item;
                day.Exercise3 = new ExerciseViewModel { Name = dayType3.Exercise3.Name, Reps = dayType3.Exercise3.Reps, CoachComment = dayType3.Exercise3.CoachComment };
            }

            return day;
        }

        /// <summary>
        /// Control the visibility of the exercises grids
        /// </summary>
        private void OnNewExerciseSelected()
        {
            try
            {
                if (!Exercise1Visible)
                {
                    Exercise1Visible = true;
                }
                else if (Exercise1Visible && !Exercise2Visible)
                {
                    Exercise2Visible = true;
                }
                else if(Exercise1Visible && Exercise2Visible && !Exercise3Visible)
                {
                    Exercise3Visible = true;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Create exercise");
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                LoadBWSDay(HttpUtility.UrlDecode(name));
            }
        }

        private int type;
        public int Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        private ExerciseViewModel exercise1 = new ExerciseViewModel();
        private ExerciseViewModel exercise2 = new ExerciseViewModel();
        private ExerciseViewModel exercise3 = new ExerciseViewModel();
        public ExerciseViewModel Exercise1
        {
            get => exercise1;
            set => SetProperty(ref exercise1, value);
        }

        public ExerciseViewModel Exercise2
        {
            get => exercise2;
            set => SetProperty(ref exercise2, value);
        }

        public ExerciseViewModel Exercise3
        {
            get => exercise3;
            set => SetProperty(ref exercise3, value);
        }


        private bool exercise1Visible;
        private bool exercise2Visible;
        private bool exercise3Visible;
        public bool Exercise1Visible
        {
            get => exercise1Visible;
            set => SetProperty(ref exercise1Visible, value);
        }

        public bool Exercise2Visible
        {
            get => exercise2Visible;
            set => SetProperty(ref exercise2Visible, value);
        }
        public bool Exercise3Visible
        {
            get => exercise3Visible;
            set => SetProperty(ref exercise3Visible, value);
        }

        //private string exercise1Name;
        //private string exercise1Reps;
        //private string exercise1CoachComment;
        //private string exercise1Comment;

        //private string exercise2Name;
        //private string exercise2Reps;
        //private string exercise2CoachComment;
        //private string exercise2Comment;

        //private string exercise3Name;
        //private string exercise3Reps;
        //private string exercise3CoachComment;
        //private string exercise3Comment;

        void SetViewModelProperties(BWSDay day)
        {
            BWSDay2 usedDay = (BWSDay2)day;
            Type = day.Type;
            Exercise1.Name = usedDay.Exercise1.Name;
            Exercise1.Reps = usedDay.Exercise1.Reps;
            Exercise1.CoachComment = usedDay.Exercise1.CoachComment;
            Exercise1.Comment = usedDay.Exercise1.Comment;

            Exercise2.Name = usedDay.Exercise2.Name;
            Exercise2.Reps = usedDay.Exercise2.Reps;
            Exercise2.CoachComment = usedDay.Exercise2.CoachComment;
            Exercise2.Comment = usedDay.Exercise2.Comment;

            //Exercise1Name = usedDay.Exercise1.Name;
            //Exercise1Reps = usedDay.Exercise1.Reps;
            //Exercise1Comment = usedDay.Exercise1.Comment;
            //Exercise1CoachComment = usedDay.Exercise1.CoachComment;

            //Exercise2Name = usedDay.Exercise2.Name;
            //Exercise2Reps = usedDay.Exercise2.Reps;
            //Exercise2Comment = usedDay.Exercise2.Comment;
            //Exercise2CoachComment = usedDay.Exercise2.CoachComment;

            if (day.Type == 3)
            {
                BWSDay3 anotherUsedDay = (BWSDay3)day;
                Exercise3.Name = anotherUsedDay.Exercise3.Name;
                Exercise3.Reps = anotherUsedDay.Exercise3.Reps;
                Exercise3.Comment = anotherUsedDay.Exercise3.Comment;
                Exercise3.CoachComment = anotherUsedDay.Exercise3.CoachComment;

                //Exercise3Name = anotherUsedDay.Exercise3.Name;
                //Exercise3Reps = anotherUsedDay.Exercise3.Reps;
                //Exercise3Comment = anotherUsedDay.Exercise3.Comment;
                //Exercise3CoachComment = anotherUsedDay.Exercise3.CoachComment;
            }
        }
        #region SetProperties

        //public string Exercise1Name
        //{
        //    get => exercise1Name;
        //    set => SetProperty(ref exercise1Name, value);
        //}
        //public string Exercise1Reps
        //{
        //    get => exercise1Reps;
        //    set => SetProperty(ref exercise1Reps, value);
        //}
        //public string Exercise1CoachComment
        //{
        //    get => exercise1CoachComment;
        //    set => SetProperty(ref exercise1CoachComment, value);
        //}
        //public string Exercise1Comment
        //{
        //    get => exercise1Comment;
        //    set => SetProperty(ref exercise1Comment, value);
        //}

        //public string Exercise2Name
        //{
        //    get => exercise2Name;
        //    set => SetProperty(ref exercise2Name, value);
        //}
        //public string Exercise2Reps
        //{
        //    get => exercise2Reps;
        //    set => SetProperty(ref exercise2Reps, value);
        //}
        //public string Exercise2CoachComment
        //{
        //    get => exercise2CoachComment;
        //    set => SetProperty(ref exercise2CoachComment, value);
        //}
        //public string Exercise2Comment
        //{
        //    get => exercise2Comment;
        //    set => SetProperty(ref exercise2Comment, value);
        //}

        //public string Exercise3Name
        //{
        //    get => exercise3Name;
        //    set => SetProperty(ref exercise3Name, value);
        //}
        //public string Exercise3Reps
        //{
        //    get => exercise3Reps;
        //    set => SetProperty(ref exercise3Reps, value);
        //}
        //public string Exercise3CoachComment
        //{
        //    get => exercise3CoachComment;
        //    set => SetProperty(ref exercise3CoachComment, value);
        //}
        //public string Exercise3Comment
        //{
        //    get => exercise3Comment;
        //    set => SetProperty(ref exercise3Comment, value);
        //}
        #endregion

    }
}
