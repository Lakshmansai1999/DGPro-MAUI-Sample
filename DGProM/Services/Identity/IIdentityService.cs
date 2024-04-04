using DGProM.Models.Token;

namespace DGProM.Services.Identity;

public interface IIdentityService
{
    string CreateAuthorizationRequest();
    string CreateLogoutRequest(string token);
    Task<UserToken> GetTokenAsync(string code);
}