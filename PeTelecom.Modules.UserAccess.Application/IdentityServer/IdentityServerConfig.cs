﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace PeTelecom.Modules.UserAccess.Application.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource("PeTelecomAPI", "PeTelecom API")
            };

        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(CustomClaimTypes.Role, new List<string>{ CustomClaimTypes.Role })
            };

        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = {
                        "PeTelecomAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile

                    }
                }
            };
    }

}
