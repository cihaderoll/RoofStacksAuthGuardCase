namespace RoofStacksAuthGuardCase.AuthGuard.Model
{
    public class ClientStore
    {
        public IEnumerable<Client> Clients = new[]
        {
            new Client
            {
                ClientName = "Employee API",
                ClientId = "EmployeeWebAPI",
                ClientSecret = "123456789", //TODO secret ekle
                AllowedScopes = new[]{ "openid", "profile"},
                GrantType = GrantTypes.Code,
                IsActive = true,
                ClientUri = "https://localhost:7126",
                RedirectUri = "https://localhost:7126/signin-oidc"
            }
        };
    }
}
