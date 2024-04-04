using DGProM.Models.Marketing;

namespace DGProM.Services.Marketing;

public interface ICampaignService
{
    Task<IEnumerable<CampaignItem>> GetAllCampaignsAsync(string token);
    Task<CampaignItem> GetCampaignByIdAsync(int id, string token);
}