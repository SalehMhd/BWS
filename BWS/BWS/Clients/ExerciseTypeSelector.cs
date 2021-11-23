using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BWS.Clients
{
    public class ExerciseTypeSelector : DataTemplateSelector
    {
        public DataTemplate DayTypeNewTemplate { get; set; }
        public DataTemplate DayType2Template { get; set; }
        public DataTemplate DayType3Template { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            BWSDay day = item as BWSDay;
            if (day.Type == 0)
            {
                return DayTypeNewTemplate;
            }

            if (day.Type == 2)
            {
                return DayType2Template;
            }

            if(day.Type == 3)
            {
                return DayType3Template;
            }

            return null;
        }
    }
}
