using DGProM.ViewModels;
using DGProM.Views;

namespace DGProM.Views;

public partial class CampaignView : ContentPageBase
{
    public CampaignView(CampaignDetailsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}