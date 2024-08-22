using RoofStacksAuthGuardCase.EmployeeService.DTOs;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Abstract
{
    public interface ITokenService
    {
        /// <summary>
        /// Make a request to the relevant identity server using client credentials 
        /// to obtain the access token and other necessary information.
        /// </summary>
        /// <returns></returns>
        Task<TokenRequestDto> GetAccessTokenAsync();
    }
}
