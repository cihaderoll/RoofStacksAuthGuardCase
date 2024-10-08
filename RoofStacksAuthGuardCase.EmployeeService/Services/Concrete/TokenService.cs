﻿using IdentityModel.Client;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;
using System.Net.Http;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public TokenService(IHttpClientFactory httpClientFactory,
                                  IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<TokenRequestDto> GetAccessTokenAsync()
        {
            var serverClient = _httpClientFactory.CreateClient();

            var discoveryDoc = await serverClient.GetDiscoveryDocumentAsync(_config.GetValue<string>("Authorization:Authority"));
            if(discoveryDoc.IsError)
                throw new UnauthorizedAccessException(discoveryDoc.Error);

            var tokenResponse = await serverClient
                .RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discoveryDoc.TokenEndpoint,
                    ClientId = _config.GetValue<string>("Authorization:ClientId") ?? "EmployeeAPI",
                    ClientSecret = _config.GetValue<string>("Authorization:ClientSecret"),
                    Scope = _config.GetValue<string>("Authorization:Scope")
                });
            if (tokenResponse.IsError)
                throw new UnauthorizedAccessException(tokenResponse.Error);

            return new TokenRequestDto
            {
                AccessToken = tokenResponse.AccessToken,
                ExpiresIn = tokenResponse.ExpiresIn,
                TokenType = tokenResponse.TokenType,
                Scope = tokenResponse.Scope
            };
        }
    }
}
