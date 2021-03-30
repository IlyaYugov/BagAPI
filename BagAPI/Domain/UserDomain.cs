using Domain.IRepositories;
using DTO;

namespace Domain
{
    public class UserDomain
    {
        private IUserRepository _repository;

        public UserDomain(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserDto GetUser(int id)
        {
            return _repository.GetUser(id);
        }
        public void GetUserList()
        {
        }
        public UserDto CreateUser(UserDto user)
        {
            return _repository.CreateUser(user);
        }

        public UserDto UpdateUser(UserDto user)
        {
            return _repository.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _repository.DeleteUser(id);
        }
    }
}
