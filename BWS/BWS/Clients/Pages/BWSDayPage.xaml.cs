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
    public partial class BWSDayPage : ContentPage
    {
        public BWSDayPage()
        {
            InitializeComponent();
            BindingContext = new BWSDayViewModel();
        }
    }
}