using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using ShipmentSystem.Application.Interfaces.Auth;

namespace ShipmentSystem.Infrastructure.Services.Auth;

public class Auth0Service : IAuth0Service
{
    private readonly HttpClient _httpClient;
    private readonly Auth0Settings _settings;

    public Auth0Service(HttpClient httpClient, IOptions<Auth0Settings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<(bool IsSuccess, string? AccessToken, string? ErrorMessage)> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", email },
                { "password", password },
                { "audience", _settings.Audience },
                { "client_id", _settings.ClientId },
                { "client_secret", _settings.ClientSecret },
                { "scope", "openid profile email" },
                { "connection", "Username-Password-Authentication" }
            };

            var response = await _httpClient.PostAsync(
                $"https://{_settings.Domain}/oauth/token",
                new FormUrlEncodedContent(body),
                cancellationToken
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                return (
                    false,
                    null,
                    $"Auth0 login failed. StatusCode: {response.StatusCode}, Error: {error}"
                );
            }

            var tokenResponse = await response.Content.ReadFromJsonAsync<Auth0TokenResponse>(
                cancellationToken: cancellationToken
            );
            return (true, tokenResponse?.AccessToken, null);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
