using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Storage;

namespace Salesync.SalesRep.Pwa.Auth;

public sealed class SalesyncAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly ClaimsPrincipal AnonymousUser = new(new ClaimsIdentity());

    private readonly AuthStorageService _authStorage;

    public SalesyncAuthenticationStateProvider(AuthStorageService authStorage)
    {
        _authStorage = authStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var session = await _authStorage.GetSessionAsync();

        if (!IsValidSession(session))
        {
            if (session is not null)
            {
                await _authStorage.ClearSessionAsync();
            }

            return CreateAnonymousState();
        }

        return CreateAuthenticatedState(session!);
    }

    public async Task SignInAsync(TokenResponse session)
    {
        ArgumentNullException.ThrowIfNull(session);

        await _authStorage.SaveSessionAsync(session);

        var authenticationState =
            CreateAuthenticatedState(session);

        NotifyAuthenticationStateChanged(
            Task.FromResult(authenticationState));
    }

    public async Task SignOutAsync()
    {
        await _authStorage.ClearSessionAsync();

        NotifyAuthenticationStateChanged(
            Task.FromResult(CreateAnonymousState()));
    }

    private static bool IsValidSession(TokenResponse? session)
    {
        return session is not null
               && !string.IsNullOrWhiteSpace(session.Token)
               && session.ExpiresAt > DateTime.UtcNow;
    }

    private static AuthenticationState CreateAuthenticatedState(TokenResponse session)
    {
        var claims = new List<Claim>
        {
            new(
                ClaimTypes.NameIdentifier,
                session.UserName),

            new(
                ClaimTypes.Name,
                session.FullName),

            new(
                ClaimTypes.Role,
                session.Role),

            new(
                "user_name",
                session.UserName),

            new(
                "token_expiration",
                session.ExpiresAt.ToString("O"))
        };

        if (session.BranchId.HasValue)
        {
            claims.Add(
                new Claim(
                    "branch_id",
                    session.BranchId.Value.ToString()));
        }

        if (session.BusinessUnitId.HasValue)
        {
            claims.Add(
                new Claim(
                    "business_unit_id",
                    session.BusinessUnitId.Value.ToString()));
        }

        AddSalesRepIdClaim(claims, session.Token);

        var identity = new ClaimsIdentity(claims, authenticationType: "SalesyncJwt");

        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    private static void AddSalesRepIdClaim(ICollection<Claim> claims, string token)
    {
        var salesRepIdValue = JwtClaimReader.GetClaimValue(token, "SalesRepId");

        if (!int.TryParse(
                salesRepIdValue,
                out var salesRepId) ||
            salesRepId <= 0)
        {
            return;
        }

        claims.Add(new Claim("sales_rep_id", salesRepId.ToString()));
    }

    private static AuthenticationState CreateAnonymousState()
    {
        return new AuthenticationState(AnonymousUser);
    }
}