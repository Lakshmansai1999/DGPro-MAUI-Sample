using DGProM.ViewModels;

namespace DGProM.Views;

public partial class CampaignDetailsView : ContentPage
{
    public CampaignDetailsView(CampaignDetailsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}
