using System;
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
            new ApiResource("resource_photo_stock")
            {
                Scopes =
                {
                    "photo_stock_full_permission"
                }
            },
            new ApiResource("resource_basket")
            {
                Scopes =
                {
                    "basket_full_permission"
                }
            },
            new ApiResource("resource_discount")
            {
                Scopes =
                {
                    "discount_full_permission"
                }
            },
            new ApiResource("resource_fake_payment")
            {
                Scopes =
                {
                    "fake_payment_full_permission"
                }
            },

            new ApiResource("resource_order")
            {
                Scopes =
                {
                    "order_full_permission"
                }
            },   new ApiResource("resource_gateway")
            {
                Scopes =
                {
                    "gateway_full_permission"
                }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource()
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "User's roles",
                    UserClaims = new[] { "roles" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_full_permission", "Catalog API Permission"),
                new ApiScope("photo_stock_full_permission", "Photo API Permission"),
                new ApiScope("basket_full_permission", "Basket API Permission"),
                new ApiScope("discount_full_permission", "Discount API Permission"),
                new ApiScope("order_full_permission", "Order API Permission"),
                new ApiScope("fake_payment_full_permission", "Fake Payment API"),
                new ApiScope("gateway_full_permission", "GateWay API"),
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
                        "gateway_full_permission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }
                },
                new Client()
                {
                    ClientId = "WebMvcClientForUser",
                    AllowOfflineAccess = true,
                    ClientName = "Asp.Net Core MVC",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "basket_full_permission",
                        "discount_full_permission",
                        "order_full_permission",
                        "fake_payment_full_permission",
                        "gateway_full_permission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles"
                    },
                    AccessTokenLifetime = 1 * 60 * 60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}