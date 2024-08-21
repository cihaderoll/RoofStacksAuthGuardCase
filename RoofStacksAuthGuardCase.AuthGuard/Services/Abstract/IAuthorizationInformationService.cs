using RoofStacksAuthGuardCase.AuthGuard.Model;

namespace RoofStacksAuthGuardCase.AuthGuard.Services.Abstract
{
    public interface IAuthorizationInformationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="requestedScope"></param>
        /// <returns></returns>
        string GenerateAuthorizationCode(string clientId, IList<string> requestedScope);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        AuthorizationInformation GetClientDataByCode(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        AuthorizationInformation RemoveClientDataByCode(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="requestdScopes"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        AuthorizationInformation UpdatedClientDataByCode(string key, IList<string> requestdScopes,
            string userName, string password = null, string nonce = null);
    }
}
