// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Sample.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("Sample.API.Audience")
            {
                Scopes =
                {
                    "Sample.API.Scope"
                },
                UserClaims =
                {
                    "name",
                    "email"
                }
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Sample.API.Scope"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "Sample.API.ClientId",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:7021/swagger/oauth2-redirect.html" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "email", "Sample.API.Scope", "offline_access" }
                },
            };
    }
}