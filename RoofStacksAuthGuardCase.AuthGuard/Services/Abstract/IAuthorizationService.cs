using RoofStacksAuthGuardCase.AuthGuard.Model;

namespace RoofStacksAuthGuardCase.AuthGuard.Services.Abstract
{
    public interface IAuthorizationService
    {
        AuthorizeResponse Authorize(AuthorizationRequest authorizationRequest);

        TokenResponse GenerateToken();
    }
}
