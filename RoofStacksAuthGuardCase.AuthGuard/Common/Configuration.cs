using Duende.IdentityServer.Models;
using IdentityModel;

namespace RoofStacksAuthGuardCase.AuthGuard.Common
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> GetApiScopes()
            => new List<ApiScope>
            {
                new ApiScope("employees")
            };

        public static IEnumerable<Client> GetClients()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "EmployeeAPI",
                    ClientSecrets = { new Secret("EmployeeAPI_Secret".ToSha256()) },

                    // No interactive user, uses the ClientId & Secret for authentication.
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // Scopes that this client has access to.
                    AllowedScopes = { "employees" }
                }
            };
    }
}
