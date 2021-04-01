using DTO;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        UserDto GetUser(int Id);
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(UserDto userDto);
        bool DeleteUser(int id);
        IEnumerable<string> GetMessangers(int id);
    }
}