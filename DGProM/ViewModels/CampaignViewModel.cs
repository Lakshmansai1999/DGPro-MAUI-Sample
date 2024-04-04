using DGProM.Models.Marketing;
using DGProM.Services;
using DGProM.Services.AppEnvironment;
using DGProM.Services.Settings;
using DGProM.ViewModels.Base;

namespace DGProM.ViewModels;

public partial class CampaignViewModel : ViewModelBase
{
    private readonly ISettingsService _settingsService;
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ObservableCollectionEx<CampaignItem> _campaigns = new ();

    public IReadOnlyList<CampaignItem> Campaigns => _campaigns;

    public CampaignViewModel(
        IAppEnvironmentService appEnvironmentService,
        INavigationService navigationService, ISettingsService settingsService)
        : base(navigationService)
    {
        _appEnvironmentService = appEnvironmentService;
        _settingsService = settingsService;
    }

    public override async Task InitializeAsync()
    {
        await IsBusyFor(
            async () =>
            {
                // Get campaigns by user
                var campaigns = await _appEnvironmentService.CampaignService.GetAllCampaignsAsync(_settingsService.AuthAccessToken);
                _campaigns.ReloadData(campaigns);
            });
    }

    [RelayCommand]
    private async Task GetCampaignDetailsAsync(CampaignItem campaign)
    {
        if (campaign is null)
        {
            return;
        }

        await NavigationService.NavigateToAsync(
            "CampaignDetails",
            new Dictionary<string, object> { { nameof(Campaign.Id), campaign.Id } });
    }
}