﻿// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using OpenIddict4.Models;
// using Microsoft.Extensions.Configuration;
// using Volo.Abp.Authorization.Permissions;
// using Volo.Abp.DependencyInjection;
// using Volo.Abp.Guids;
// using Volo.Abp.MultiTenancy;
// using Volo.Abp.PermissionManagement;
// using Volo.Abp.Uow;


// namespace Tasky.DbMigrator;

// public class OpenIddictDataSeeder : ITransientDependency
// {
//     private readonly IConfiguration _configuration;
//     private readonly ICurrentTenant _currentTenant;
//     private readonly IGuidGenerator _guidGenerator;
//     private readonly IPermissionDataSeeder _permissionDataSeeder;

//     public OpenIddictDataSeeder(
//         IGuidGenerator guidGenerator,
//         IPermissionDataSeeder permissionDataSeeder,
//         IConfiguration configuration,
//         ICurrentTenant currentTenant)
//     {
//         _guidGenerator = guidGenerator;
//         _permissionDataSeeder = permissionDataSeeder;
//         _configuration = configuration;
//         _currentTenant = currentTenant;
//     }

//     [UnitOfWork]
//     public async virtual Task SeedAsync()
//     {
//         using (_currentTenant.Change(null))
//         {
//             // await _identityResourceDataSeeder.CreateStandardResourcesAsync();
//             await CreateApiResourcesAsync();
//             await CreateApiScopesAsync();
//             await CreateClientsAsync();
//         }
//     }

//     private async Task CreateClientsAsync()
//     {
//         var clients = _configuration.GetSection("Clients").Get<List<ServiceClient>>();
//         var commonScopes = new[] {
//             "email",
//             "openid",
//             "profile",
//             "role",
//             "phone",
//             "address"
//         };

//         foreach (var client in clients)
//         {
//             await CreateClientAsync(
//                 client.ClientId,
//                 commonScopes.Union(client.Scopes),
//                 client.GrantTypes,
//                 client.ClientSecret.Sha256(),
//                 requireClientSecret: false,
//                 redirectUris: client.RedirectUris,
//                 postLogoutRedirectUris: client.PostLogoutRedirectUris,
//                 corsOrigins: client.AllowedCorsOrigins
//             );
//         }
//     }


//     private async Task CreateApiResourcesAsync()
//     {
//         var commonApiUserClaims = new[] {
//             "email",
//             "email_verified",
//             "name",
//             "phone_number",
//             "phone_number_verified",
//             "role"
//         };

//         var apiResources = _configuration.GetSection("ApiResource").Get<string[]>();

//         foreach (var item in apiResources)
//         {
//             await CreateApiResourceAsync(item, commonApiUserClaims);
//         }
//     }

//     private async Task CreateApiScopesAsync()
//     {
//         var apiScopes = _configuration.GetSection("ApiScope").Get<string[]>();
//         foreach (var item in apiScopes)
//         {
//             await CreateApiScopeAsync(item);
//         }
//     }

//     private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
//     {
//         var apiResource = await _apiResourceRepository.FindByNameAsync(name);
//         if (apiResource == null)
//         {
//             apiResource = await _apiResourceRepository.InsertAsync(
//                 new ApiResource(
//                     _guidGenerator.Create(),
//                     name,
//                     name + " API"
//                 ),
//                 true
//             );
//         }

//         foreach (var claim in claims)
//         {
//             if (apiResource.FindClaim(claim) == null)
//             {
//                 apiResource.AddUserClaim(claim);
//             }
//         }

//         return await _apiResourceRepository.UpdateAsync(apiResource);
//     }

//     private async Task<ApiScope> CreateApiScopeAsync(string name)
//     {
//         var apiScope = await _apiScopeRepository.FindByNameAsync(name);
//         if (apiScope == null)
//         {
//             apiScope = await _apiScopeRepository.InsertAsync(
//                 new ApiScope(
//                     _guidGenerator.Create(),
//                     name,
//                     name + " API"
//                 ),
//                 true
//             );
//         }

//         return apiScope;
//     }

//     private async Task<Client> CreateClientAsync(
//         string name,
//         IEnumerable<string> scopes,
//         IEnumerable<string> grantTypes,
//         string secret = null,
//         IEnumerable<string> redirectUris = null,
//         IEnumerable<string> postLogoutRedirectUris = null,
//         string frontChannelLogoutUri = null,
//         bool requireClientSecret = true,
//         bool requirePkce = false,
//         IEnumerable<string> permissions = null,
//         IEnumerable<string> corsOrigins = null)
//     {
//         var client = await _clientRepository.FindByClientIdAsync(name);
//         if (client == null)
//         {
//             client = await _clientRepository.InsertAsync(
//                 new Client(
//                     _guidGenerator.Create(),
//                     name
//                 )
//                 {
//                     ClientName = name,
//                     ProtocolType = "oidc",
//                     Description = name,
//                     AlwaysIncludeUserClaimsInIdToken = true,
//                     AllowOfflineAccess = true,
//                     AbsoluteRefreshTokenLifetime = 31536000, //365 days
//                     AccessTokenLifetime = 31536000, //365 days
//                     AuthorizationCodeLifetime = 300,
//                     IdentityTokenLifetime = 300,
//                     RequireConsent = false,
//                     FrontChannelLogoutUri = frontChannelLogoutUri,
//                     RequireClientSecret = requireClientSecret,
//                     RequirePkce = requirePkce
//                 },
//                 true
//             );
//         }

//         foreach (var scope in scopes)
//         {
//             if (client.FindScope(scope) == null)
//             {
//                 client.AddScope(scope);
//             }
//         }

//         foreach (var grantType in grantTypes)
//         {
//             if (client.FindGrantType(grantType) == null)
//             {
//                 client.AddGrantType(grantType);
//             }
//         }

//         if (!secret.IsNullOrEmpty())
//         {
//             if (client.FindSecret(secret) == null)
//             {
//                 client.AddSecret(secret);
//             }
//         }

//         foreach (var redirectUrl in redirectUris)
//         {
//             if (client.FindRedirectUri(redirectUrl) == null)
//             {
//                 client.AddRedirectUri(redirectUrl);
//             }
//         }

//         foreach (var postLogoutRedirectUri in postLogoutRedirectUris)
//         {
//             if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
//             {
//                 client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
//             }
//         }

//         if (permissions != null)
//         {
//             await _permissionDataSeeder.SeedAsync(
//                 ClientPermissionValueProvider.ProviderName,
//                 name,
//                 permissions
//             );
//         }

//         if (corsOrigins != null)
//         {
//             foreach (var origin in corsOrigins)
//             {
//                 if (!origin.IsNullOrWhiteSpace() && client.FindCorsOrigin(origin) == null)
//                 {
//                     client.AddCorsOrigin(origin);
//                 }
//             }
//         }

//         return await _clientRepository.UpdateAsync(client);
//     }

// }