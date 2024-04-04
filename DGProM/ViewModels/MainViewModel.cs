using DGProM.Services;
using DGProM.ViewModels.Base;

namespace DGProM.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    [RelayCommand]
    private async Task SettingsAsync()
    {
        await NavigationService.NavigateToAsync("Settings");
    }
}