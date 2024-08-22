using IdentityModel.Client;
using Moq;
using RoofStacksAuthGuardCase.EmployeeService.Controllers.v1;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;
using System.Net.Http;

namespace RoofStacksAuthGuardCase.EmployeeAPITest
{
    public class TokenServiceTest
    {
        private static HttpClient sharedClient = new();

        private readonly Mock<ITokenService> _tokenMoqService;
        private readonly SecurityController _securityController;

        public TokenServiceTest()
        {
            _tokenMoqService = new Mock<ITokenService>();
            _securityController = new SecurityController(_tokenMoqService.Object);
        }

        [Fact]
        public async Task TokenService_GetAccessTokenAsync_ShouldReturnTokenRequestDto()
        {
            // Arrange
            var getTokenAction = async () => 
            {
                var discoveryDoc = await TokenServiceTest.sharedClient.GetDiscoveryDocumentAsync("https://localhost:7178/");
                Assert.True(!discoveryDoc.IsError);

                var tokenResponse = await TokenServiceTest.sharedClient
                    .RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = discoveryDoc.TokenEndpoint,
                        ClientId = "EmployeeAPI",
                        ClientSecret = "57cd3314-b25e-4c24-a88d-869feb2822b0",
                        Scope = "employees"
                    });
                Assert.True(!tokenResponse.IsError);

                return new TokenRequestDto
                {
                    AccessToken = tokenResponse.AccessToken,
                    ExpiresIn = tokenResponse.ExpiresIn,
                    TokenType = tokenResponse.TokenType,
                    Scope = tokenResponse.Scope
                };
            };

            _tokenMoqService.Setup(service => service.GetAccessTokenAsync())
                .Returns(getTokenAction);

            // Act
            var result = await _tokenMoqService.Object.GetAccessTokenAsync();

            // Assert
            Assert.NotNull(result.AccessToken);
            Assert.True(result.Scope == "employees");
            Assert.True(string.Equals(result.TokenType, "Bearer", StringComparison.OrdinalIgnoreCase));
        }
    }
}
