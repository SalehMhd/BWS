using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BWS.Clients
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBWSDayPage : ContentPage
    {
        public NewBWSDayPage()
        {
            InitializeComponent();
            BindingContext = new BWSDayViewModel();
        }
    }
}