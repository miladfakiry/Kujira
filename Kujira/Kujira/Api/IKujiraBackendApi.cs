using Kujira.Api.Requests;
using RestEase;

namespace Kujira.Api
{
    public interface IKujiraBackendApi
    {
        [Get("/api/Users")]
        Task<IEnumerable<UserRequest>> GetUsers();

        [Put("/api/Users/{id}")]
        Task UpdateUser([Path] Guid id, [Body] UserRequest userRequest);

        [Delete("/api/Users/{id}")]
        Task<IEnumerable<UserRequest>> DeleteUser([Path]Guid id);





    }
}
