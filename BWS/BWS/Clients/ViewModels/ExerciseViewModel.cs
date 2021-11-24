using BWS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWS.Clients
{
    public class ExerciseViewModel : BaseViewModel
    {
        private string name;
        private string reps;
        private string coachComment;
        private string comment;
        private bool showButton;
        private bool showInfo;

        public string DayName { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Reps
        {
            get => reps;
            set => SetProperty(ref reps, value);
        }
        public string CoachComment
        {
            get => coachComment;
            set => SetProperty(ref coachComment, value);
        }
        public string Comment
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }
        public bool ShowButton
        {
            get => showButton;
            set => SetProperty(ref showButton, value);
        }
        public bool ShowInfo
        {
            get => !showInfo;
            set => SetProperty(ref showInfo, !value);
        }

    }

}
