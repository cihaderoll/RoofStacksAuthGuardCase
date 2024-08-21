using RoofStacksAuthGuardCase.EmployeeService.DTOs;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Abstract
{
    public interface ITokenService
    {
        Task<TokenRequestDto> GetAccessTokenAsync();
    }
}
