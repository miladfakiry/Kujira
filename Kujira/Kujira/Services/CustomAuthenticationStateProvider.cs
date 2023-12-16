using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Kujira.Gui.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationService _authService;

    public CustomAuthenticationStateProvider(AuthenticationService authService)
    {
        _authService = authService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _authService.GetTokenAsync();
        var identity = new ClaimsIdentity();

        if (!string.IsNullOrEmpty(token))
        {
            identity = await _authService.GetClaimsIdentityFromToken(token);
        }

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public async Task UpdateAuthenticationState()
    {
        var authState = await GetAuthenticationStateAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    public void NotifyUserLogout()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }

   
}