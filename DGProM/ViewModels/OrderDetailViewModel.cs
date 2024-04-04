using DGProM.Models.Orders;
using DGProM.Services;
using DGProM.Services.AppEnvironment;
using DGProM.Services.Settings;
using DGProM.ViewModels.Base;

namespace DGProM.ViewModels;

[QueryProperty(nameof(OrderNumber), "OrderNumber")]
public partial class OrderDetailViewModel : ViewModelBase
{
    private readonly ISettingsService _settingsService;
    private readonly IAppEnvironmentService _appEnvironmentService;

    [ObservableProperty]
    private Order _order;

    [ObservableProperty]
    private bool _isSubmittedOrder;

    [ObservableProperty]
    private string _orderStatusText;

    [ObservableProperty]
    private int _orderNumber;

    public OrderDetailViewModel(
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
                // Get order detail info
                var authToken = _settingsService.AuthAccessToken;
                Order = await _appEnvironmentService.OrderService.GetOrderAsync(OrderNumber, authToken);
                IsSubmittedOrder = Order.OrderStatus == OrderStatus.Submitted;
                OrderStatusText = Order.OrderStatus.ToString().ToUpper();
            });
    }

    [RelayCommand]
    private async Task ToggleCancelOrderAsync()
    {
        var authToken = _settingsService.AuthAccessToken;

        var result = await _appEnvironmentService.OrderService.CancelOrderAsync(Order.OrderNumber, authToken);

        if (result)
        {
            OrderStatusText = OrderStatus.Cancelled.ToString().ToUpper();
        }
        else
        {
            Order = await _appEnvironmentService.OrderService.GetOrderAsync(Order.OrderNumber, authToken);
            OrderStatusText = Order.OrderStatus.ToString().ToUpper();
        }

        IsSubmittedOrder = false;
    }
}