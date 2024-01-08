using System.Net.Http.Headers;

namespace Kujira.Gui.Services;

public class AuthorizedHttpService
{
    private readonly AuthenticationService _authService;
    private readonly HttpClient _httpClient;

    public AuthorizedHttpService(HttpClient httpClient, AuthenticationService authService)
    {
        _httpClient = httpClient;
        _authService = authService;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        var token = await _authService.GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await _httpClient.SendAsync(request);
    }
}