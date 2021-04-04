using DTO;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        UserDto GetUser(string email);
        UserDto GetUser(string email, string password);
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(UserDto userDto);
        bool DeleteUser(string email);
    }
}