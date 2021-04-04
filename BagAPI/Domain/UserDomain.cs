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

        public UserResult GetUser(string email)
        {
            var result = new UserResult();
            result.User = _repository.GetUser(email);

            if (result.User == null)
            {
                result.ExceptionNessage = "User with this email not foundInDb";
                return result;
            }

            return result;
        }
        public UserResult GetUser(string email, string password)
        {
            var result = new UserResult();
            result.User = _repository.GetUser(email, password);

            if (result.User == null)
            {
                result.ExceptionNessage = "User with this email not foundInDb";
                return result;
            }

            return result;
        }

        public UserResult CreateUser(UserDto user)
        {
            var userInDb = _repository.GetUser(user.Email);

            var result = new UserResult();

            if (userInDb != null)
            {
                result.ExceptionNessage = "User with this email already exist";
                return result;
            } 

            result.User = _repository.CreateUser(user);

            return result;
        }

        public UserResult UpdateUser(UserDto user)
        {
            var updatedUser = _repository.UpdateUser(user);

            var result = new UserResult();
            if (updatedUser == null)
            {
                result.ExceptionNessage = "User with this email already exist";
            }

            result.User = updatedUser;

            return result;
        }

        public bool DeleteUser(string email)
        {
            return _repository.DeleteUser(email);
        }
    }
}
