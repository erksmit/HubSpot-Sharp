// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OAuthTokenRefresher.cs" company="">
//   
// </copyright>
// <summary>
//   Manages a <see cref="HubSpotToken" /> by periodically refreshing the access token.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// Manages a <see cref="HubSpotToken" /> by periodically refreshing the access token.
    /// </summary>
    public class OAuthTokenRefresher
    {
        /// <summary>
        /// Gets the HubSpotToken that is being managed.
        /// </summary>
        public HubSpotToken Token { get; }

        /// <summary>
        /// Gets or sets the client id of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the application
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect url that was used to authenticate the user.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the HubSpot api that will be used to make the authentication calls.
        /// </summary>
        public AuthenticationApi Api { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the refresher is currently running
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The cancellation token used to cancel the refresh task.
        /// </summary>
        private CancellationTokenSource cancellation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenRefresher"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="api">
        /// The api.
        /// </param>
        /// <param name="clientId">
        /// The client id.
        /// </param>
        /// <param name="clientSecret">
        /// The client secret.
        /// </param>
        /// <param name="redirectUri">
        /// The redirect uri.
        /// </param>
        public OAuthTokenRefresher(
            HubSpotToken token,
            AuthenticationApi api,
            string clientId,
            string clientSecret,
            string redirectUri)
        {
            Token = token;
            Api = api;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initiates the refresh process and continue refreshing the token when it expires.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        public async void Start()
        {
            if (IsActive)
            {
                throw new InvalidOperationException("Token refresher was already running");
            }

            IsActive = true;
            cancellation = new CancellationTokenSource();
            await OnRefresh();
        }

        /// <summary>
        /// Signals that the token should no longer be refreshed anymore
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        public void Stop()
        {
            IsActive = false;
            cancellation.Cancel();
        }

        /// <summary>
        /// Refreshes the token and runs the function again when the token expires.
        /// </summary>
        /// <returns>A <see cref="Task" /> that completes when the token is refreshed.</returns>
        private async Task OnRefresh()
        {
            var requestForm = new GrantRequestOptions
            {
                GrantType = GrantType.RefreshToken,
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                RedirectUri = RedirectUri,
                RefreshToken = Token.RefreshToken
            };

            var response = await Api.ExchangeTokens(requestForm);
            Token.AccessToken = response.AccessToken;

            Token.ExpiresAt = DateTime.UtcNow.AddSeconds(response.ExpiresIn);

            // we will refresh again 2 minutes before the token expires
            _ = Task.Delay(TimeSpan.FromSeconds(response.ExpiresIn - 120), cancellation.Token)
                .ContinueWith(_ => OnRefresh());
        }
    }
}