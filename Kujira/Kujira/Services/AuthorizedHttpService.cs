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

        Console.WriteLine($"Senden der Anfrage mit Header: {request.Headers.Authorization}");

        return await _httpClient.SendAsync(request);
    }
}