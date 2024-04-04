using DGProM.Models.Basket;
using DGProM.Models.Catalog;
using DGProM.Models.Marketing;

namespace DGProM.Services.FixUri;

public interface IFixUriService
{
    void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
    void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
    void FixCampaignItemPictureUri(IEnumerable<CampaignItem> campaignItems);
}