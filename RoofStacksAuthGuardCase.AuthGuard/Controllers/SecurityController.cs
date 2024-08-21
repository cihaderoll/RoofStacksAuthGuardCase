using Microsoft.AspNetCore.Mvc;
using RoofStacksAuthGuardCase.AuthGuard.Model;
using RoofStacksAuthGuardCase.AuthGuard.Services.Abstract;

namespace RoofStacksAuthGuardCase.AuthGuard.Controllers
{
    public class SecurityController : Controller
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IAuthorizationService _authorizeService;
        //private readonly IAuthorizationInformationService _authorizationInformationService;

        //public SecurityController(IHttpContextAccessor httpContextAccessor,
        //                          IAuthorizationService authorizeService,
        //                          IAuthorizationInformationService authorizationInformationService)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //    _authorizeService = authorizeService;
        //    _authorizationInformationService = authorizationInformationService;
        //}

        //[HttpPost("security/login")]
        //public JsonResult Login(LoginRequest req)
        //{
            


        //    return new JsonResult("yess");
        //}

        //[HttpGet("security/authorize")]
        //public IActionResult Authorize(AuthorizationRequest authorizationRequest)
        //{
        //    var result = _authorizeService.Authorize(authorizationRequest);

        //    if (result.HasError)
        //        return new JsonResult("testttt");

        //    var loginModel = new LoginRequest
        //    {
        //        RedirectUri = result.RedirectUri,
        //        Code = result.Code,
        //        RequestedScopes = result.RequestedScopes,
        //        Nonce = result.Nonce
        //    };


        //    return View("Login", loginModel);
        //}

        //[HttpGet("security/token")]
        //public JsonResult Token()
        //{
        //    var result = _authorizeService.GenerateToken();

        //    if (result.HasError)
        //        return Json("0");

        //    return Json(result);
        //}

        //public IActionResult Error(string error)
        //{
        //    return View(error);
        //}
    }
}
