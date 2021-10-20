
using Xamarin.Forms;

namespace BWS.Invoices
{
    public partial class InvoicePage : ContentPage
    {
        readonly InvoiceViewModel _viewModel;

        public InvoicePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new InvoiceViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnAppearing();
        }
    }
}
