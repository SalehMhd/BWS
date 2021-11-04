using BWS.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BWS.Clients
{
    public class NewBWSDayViewModel : BaseViewModel
    {
        public ObservableCollection<Exercise> Exercises { get; }
        public Command NewsExerciseCommand { get; }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public NewBWSDayViewModel()
        {
            Exercises = new ObservableCollection<Exercise>();
            NewsExerciseCommand = new Command(OnNewExerciseSelected);
        }

        private void OnNewExerciseSelected()
        {
            try
            {
                var exercise = new Exercise();
                Exercises.Add(exercise);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Create exercise");
            }
        }

    }
}
