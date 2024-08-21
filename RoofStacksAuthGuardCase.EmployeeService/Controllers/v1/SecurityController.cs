using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofStacksAuthGuardCase.EmployeeService.Controllers.Base;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;

namespace RoofStacksAuthGuardCase.EmployeeService.Controllers.v1
{
    public class SecurityController : BaseController
    {
        private readonly ITokenService _tokenService;

        public SecurityController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpGet("oauth/token")]
        public async Task<JsonResult> LoginAsync()
        {
            return new JsonResult(await _tokenService.GetAccessTokenAsync());
        }
    }
}
