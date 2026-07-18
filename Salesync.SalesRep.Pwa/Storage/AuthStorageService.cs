using System.Text.Json;
using Microsoft.JSInterop;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Storage;

public sealed class AuthStorageService
{
    private const string SessionKey = "salesync_auth_session";

    private readonly IJSRuntime _jsRuntime;

    public AuthStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async ValueTask SaveSessionAsync(TokenResponse session)
    {
        var json = JsonSerializer.Serialize(session);

        await _jsRuntime.InvokeVoidAsync(
            "sessionStorage.setItem",
            SessionKey,
            json);
    }

    public async ValueTask<TokenResponse?> GetSessionAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string?>(
            "sessionStorage.getItem",
            SessionKey);

        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<TokenResponse>(json);
        }
        catch (JsonException)
        {
            await ClearSessionAsync();
            return null;
        }
    }

    public ValueTask ClearSessionAsync()
    {
        return _jsRuntime.InvokeVoidAsync(
            "sessionStorage.removeItem",
            SessionKey);
    }
}