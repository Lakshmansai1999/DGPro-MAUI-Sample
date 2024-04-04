using DGProM.ViewModels;

namespace DGProM.Views;

public partial class FiltersView : ContentPage
{
    public FiltersView(CatalogViewModel viewModel)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }
}
