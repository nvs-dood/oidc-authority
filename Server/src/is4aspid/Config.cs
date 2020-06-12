// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;

namespace is4aspid
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "dood",
                    UserClaims = new[]{"doodrole"},
                    DisplayName = "DOOD role"
                },
            };


        public static IEnumerable<ApiResource> Apis =>
            new[]
            {
                //new ApiResource("api1", "My API #1")
                new ApiResource("demoApi", "My demo api for the pos project"),
                new ApiResource("todos-api", "Go Example API")
            };


        public static IEnumerable<Client> Clients =>
            new[]
            {
                /*// client credentials flow client
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                },

                // MVC client using code flow + pkce
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = true,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { "http://localhost:5003/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1" }
                },

                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:5002/index.html",
                        "http://localhost:5002/callback.html",
                        "http://localhost:5002/silent.html",
                        "http://localhost:5002/popup.html",
                    },

                    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                    AllowedCorsOrigins = { "http://localhost:5002" },

                    AllowedScopes = { "openid", "profile", "api1" }
                },*/

                new Client
                {

                    ClientId = "androidClient",
                    ClientName = "AndroidClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RequireConsent = true,
                    RedirectUris = {"com.is4:/login", "com.is4:/logout"},
                    FrontChannelLogoutSessionRequired = false,
                    BackChannelLogoutUri = "com.is4:/logout",

                    AllowedScopes =
                    {
                        OidcConstants.StandardScopes.Email,
                        OidcConstants.StandardScopes.OpenId,
                        OidcConstants.StandardScopes.Profile,
                        OidcConstants.StandardScopes.Address,
                        OidcConstants.StandardScopes.Phone,
                        "demoApi"
                    },


                    AllowOfflineAccess = false
                },

                new Client
                {
                    ClientId = "postman-client",
                    ClientName = "Postman Test Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    RedirectUris = {"https://www.getpostman.com/oauth2/callback"},
                    PostLogoutRedirectUris = {"https://www.getpostman.com"},
                    AllowedCorsOrigins = {"https://www.getpostman.com"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "todos_api",
                        "dood"
                    },
                    ClientSecrets = new List<Secret>{new Secret("Pass$123".Sha256())}
                },
                new Client
                {
                    RequireClientSecret=false,
                    ClientId = "doodadmin",
                    ClientName = "Dood AdminClient",
                    RequirePkce = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    RedirectUris =
                    {
                        "http://localhost:8100/implicit/callback",
                        "com.dood:/callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:8100/implicit/logout",
                        "com.dood:/logout"
                    },
                    AllowedCorsOrigins = {"http://localhost:8100"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "dood"
                    },
                    AllowOfflineAccess = true,
                }
            };
    }
}