using Kujira.Backend.Company.Domain;

namespace Kujira.Backend.User.Domain;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;


    //public UserService(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}

    //public IEnumerable<User>? GetAll()
    //{
    //    return _userRepository.GetAll();
    //}

    //public User? Get(Guid id)
    //{
    //    return _userRepository.Get(id);
    //}

    //public void Update(User user)
    //{
    //    _userRepository.Update(user);
    //}

    //public void Delete(Guid id)
    //{
    //    _userRepository.Delete(id);
    //}

    //public void Create(User user)
    //{
    //    _userRepository.Create(user);
    //}
}