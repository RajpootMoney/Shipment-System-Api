namespace ShipmentSystem.Application.Interfaces.Auth;

public interface IAuth0Service
{
    Task<(bool IsSuccess, string? AccessToken, string? ErrorMessage)> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken
    );
}
