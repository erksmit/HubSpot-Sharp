// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OAuthTests.cs" company="">
//   
// </copyright>
// <summary>
//   Tests for the OAuth api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Authentication;

namespace Tests
{
    /// <summary>
    /// Tests for the OAuth api.
    /// </summary>
    [TestClass]
    public class OAuthTests
    {
        /// <summary>
        /// The authentication api.
        /// </summary>
        private readonly AuthenticationApi api = Config.Api.Authentication;

        /// <summary>
        /// Tests whether the api is able to retrieve information on the configured private access token.
        /// </summary>
        [TestMethod]
        public void ValidatePrivateAccessToken()
        {
            if (Config.PrivateAccessToken == null)
            {
                Assert.Fail("Private Access Token is not configured");
            }

            var info = api.GetPrivateTokenInformation(Config.PrivateAccessToken);
            Assert.IsNotNull(info);
        }

        /// <summary>
        /// Tests whether the refresh token is valid and information can be retrieved on it.
        /// </summary>
        [TestMethod]
        public void ValidateRefreshToken()
        {
            if (Config.RefreshToken == null)
            {
                Assert.Fail("Refresh Token is not configured");
            }

            var info = api.GetRefreshTokenInformation(Config.RefreshToken);
            Assert.IsNotNull(info.Token);
        }

        /// <summary>
        /// Tests performing a toke exchange request which exchanges a refresh token for an access token
        /// </summary>
        [TestMethod]
        public void OAuthAuthorize()
        {
            if (Config.RefreshToken == null)
            {
                Assert.Fail("Refresh Token is not configured");
            }

            if (Config.ClientId == null)
            {
                Assert.Fail("Client Id is not configured.");
            }

            if (Config.ClientSecret == null)
            {
                Assert.Fail("Client Secret is not configured.");
            }

            if (Config.RedirectUri == null)
            {
                Assert.Fail("Redirect uri is not configured.");
            }

            var authForm = new GrantRequestOptions
            {
                GrantType = GrantType.RefreshToken,
                RefreshToken = Config.RefreshToken,
                ClientId = Config.ClientId,
                ClientSecret = Config.ClientSecret,
                RedirectUri = Config.RedirectUri
            };
            var response = api.ExchangeTokens(authForm);

            var info = api.GetAccessTokenInformation(response.AccessToken);
            Assert.IsNotNull(info.Token);
        }

        /// <summary>
        /// Tests performing OAuth authentication using the <see cref="OAuthTokenRefresher"/>.
        /// </summary>
        [TestMethod]
        public void ManagedOAuth()
        {
            if (Config.RefreshToken == null)
            {
                Assert.Fail("Refresh Token is not configured");
            }

            if (Config.ClientId == null)
            {
                Assert.Fail("Client Id is not configured.");
            }

            if (Config.ClientSecret == null)
            {
                Assert.Fail("Client Secret is not configured.");
            }

            if (Config.RedirectUri == null)
            {
                Assert.Fail("Redirect uri is not configured.");
            }

            var token = new HubSpotToken
            {
                RefreshToken = Config.RefreshToken
            };
            var manager = new OAuthTokenRefresher(
                token,
                Config.Api,
                Config.ClientId,
                Config.ClientSecret,
                Config.RedirectUri);
            manager.Start();
            Thread.Sleep(5000);
            manager.Stop();
            var info = api.GetAccessTokenInformation(token.AccessToken);
            Assert.IsNotNull(info.Token);
        }
    }
}