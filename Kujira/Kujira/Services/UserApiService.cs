using System.Net.Http.Json;
using Kujira.Api.Requests;

namespace Kujira.Services
{
    public class UserApiService
    {

        private readonly HttpClient _http;

        public UserApiService(HttpClient http)
        {
            _http = http;
        }

        //public async Task<IEnumerable<UserRequest>> GetAllUsersAsync()
        //{
        //    try
        //    {
        //        Console.WriteLine("Das ist ein Test");
        //        var usersss = await _http.GetFromJsonAsync<IEnumerable<UserRequest>>("api/Users");
        //        return usersss;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
        //        return Enumerable.Empty<UserRequest>();
        //    }
        //}

    }
}
