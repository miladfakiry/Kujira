﻿using System.Security.Claims;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Kujira.Gui.Services;

public class AuthenticationService
{
    private readonly IJSRuntime _jsRuntime;

    public AuthenticationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task SetTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "authToken", token);
    }

    public async Task<string> GetTokenAsync()
    {
        var token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
        Console.WriteLine($"Token retrieved: {token}");
        return token;
    }

    public async Task LogoutAsync()
    {
        await RemoveTokenAsync();
    }


    public async Task RemoveTokenAsync()
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorageFunctions.removeItem", "authToken");
    }

    public async Task<ClaimsIdentity> GetClaimsIdentityFromToken(string token)
    {
        var tokenPayloadJsonElement = await _jsRuntime.InvokeAsync<JsonElement>("jwtFunctions.decodeToken", token);
        var tokenPayloadJson = tokenPayloadJsonElement.GetRawText();
        var claims = JsonSerializer.Deserialize<Dictionary<string, object>>(tokenPayloadJson);

        var claimsIdentity = new ClaimsIdentity();
        if (claims != null)
        {
            foreach (var claim in claims)
            {
                if (claim.Key == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, claim.Value.ToString()));
                }
                else
                {
                    claimsIdentity.AddClaim(new Claim(claim.Key, claim.Value.ToString()));
                }
            }
        }

        return claimsIdentity;
    }
    public async Task<Guid> GetLoggedInUserIdAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            return Guid.Empty;
        }

        var claimsIdentity = await GetClaimsIdentityFromToken(token);
        var userIdClaim = claimsIdentity.FindFirst("UserId");
        if (userIdClaim != null)
        {
            return Guid.Parse(userIdClaim.Value);
        }

        return Guid.Empty;
    }

}