using System.Net.Http.Headers;
using Salesync.SalesRep.Pwa.Storage;

namespace Salesync.SalesRep.Pwa.Auth;

public sealed class AuthMessageHandler : DelegatingHandler
{
    private readonly AuthStorageService _authStorage;

    public AuthMessageHandler(AuthStorageService authStorage)
    {
        _authStorage = authStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var session = await _authStorage.GetSessionAsync();

        if (session is not null)
        {
            if (session.ExpiresAt <= DateTime.UtcNow)
            {
                await _authStorage.ClearSessionAsync();
            }
            else if (!string.IsNullOrWhiteSpace(session.Token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        session.Token);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}