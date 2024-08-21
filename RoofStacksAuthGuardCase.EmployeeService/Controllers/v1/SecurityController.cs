using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace RoofStacksAuthGuardCase.EmployeeService.Controllers.v1
{
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public SecurityController(IHttpClientFactory httpClientFactory, 
                                  IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        [HttpGet("security/login")]
        public async Task<IActionResult> LoginAsync()
        {
            var serverClient = _httpClientFactory.CreateClient();

            var discoveryDoc = await serverClient.GetDiscoveryDocumentAsync(_config.GetValue<string>("Authorization:Authority"));

            var tokenResponse = await serverClient
                .RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discoveryDoc.TokenEndpoint,
                    ClientId = _config.GetValue<string>("Authorization:ClientId") ?? "EmployeeAPI",
                    ClientSecret = _config.GetValue<string>("Authorization:ClientSecret"),
                    Scope = _config.GetValue<string>("Authorization:Scope")
                });

            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                expires_in = tokenResponse.ExpiresIn,
                token_type = tokenResponse.TokenType,
                scope = tokenResponse.Scope
            });
        }
    }
}
