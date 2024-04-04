using DGProM.ViewModels;
using DGProM.Views;

namespace DGProM.Views
{
    public partial class BasketView : ContentPageBase
    {
        public BasketView(BasketViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}