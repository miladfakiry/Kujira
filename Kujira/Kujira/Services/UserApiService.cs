namespace Kujira.Services;

public class UserApiService
{
    private readonly HttpClient _http;

    public UserApiService(HttpClient http)
    {
        _http = http;
    }
}