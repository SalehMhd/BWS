using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BWS.Clients
{
    public class BWSExeciseView : ContentView
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(NameViewProp), typeof(string), typeof(BWSExeciseView), string.Empty);
        public static readonly BindableProperty RepsProperty = BindableProperty.Create(nameof(RepsViewProp), typeof(string), typeof(BWSExeciseView), string.Empty);
        public static readonly BindableProperty CoachCommentProperty = BindableProperty.Create(nameof(CoachCommentViewProp), typeof(string), typeof(BWSExeciseView), string.Empty);
        public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(CommentViewProp), typeof(string), typeof(BWSExeciseView), string.Empty);

        public string NameViewProp
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public string RepsViewProp
        {
            get => (string)GetValue(RepsProperty);
            set => SetValue(RepsProperty, value);
        }

        public string CoachCommentViewProp
        {
            get => (string)GetValue(CoachCommentProperty);
            set => SetValue(CoachCommentProperty, value);
        }

        public string CommentViewProp
        {
            get => (string)GetValue(CommentProperty);
            set => SetValue(CommentProperty, value);
        }

    }
}
