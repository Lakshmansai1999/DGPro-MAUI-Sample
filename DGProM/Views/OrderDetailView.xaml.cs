using DGProM.ViewModels;

namespace DGProM.Views;

public partial class OrderDetailView : ContentPageBase
{
    public OrderDetailView(OrderDetailViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
