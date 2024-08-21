using System.ComponentModel;

namespace RoofStacksAuthGuardCase.AuthGuard.Model
{
    internal enum AuthorizationGrantTypes : byte
    {
        [Description("code")]
        Code,

        [Description("Implicit")]
        Implicit,

        [Description("ClientCredentials")]
        ClientCredentials,

        [Description("ResourceOwnerPassword")]
        ResourceOwnerPassword
    }
}
