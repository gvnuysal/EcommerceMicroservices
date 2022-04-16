using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace Teknosol.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog")
            {
                Scopes =
                {
                    "catalog_full_permission"
                }
            },
            new ApiResource("photo_stock")
            {
                Scopes =
                {
                    "photo_stock_full_permission"
                }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_full_permission", "Catalog API Permission"),
                new ApiScope("photo_stock_full_permission", "Photo API Permission"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientId = "WebMvcClient",
                    ClientName = "Asp.Net Core MVC",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "catalog_full_permission",
                        "photo_stock_full_permission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }
                }
            };
    }
}