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
                    ClientSecrets = { new Secret("57cd3314-b25e-4c24-a88d-869feb2822b0".ToSha256()) },

                    // No interactive user, uses the ClientId & Secret for authentication.
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // Scopes that this client has access to.
                    AllowedScopes = { "employees" }
                }
            };
    }
}
