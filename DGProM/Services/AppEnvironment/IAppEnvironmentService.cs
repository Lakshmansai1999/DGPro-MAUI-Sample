using DGProM.Services.Basket;
using DGProM.Services.Catalog;
using DGProM.Services.Marketing;
using DGProM.Services.Order;
using DGProM.Services.User;

namespace DGProM.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    IBasketService BasketService { get; }
    ICampaignService CampaignService { get; }
    ICatalogService CatalogService { get; }
    IOrderService OrderService { get; }
    IUserService UserService { get; }

    void UpdateDependencies(bool useMockServices);
}