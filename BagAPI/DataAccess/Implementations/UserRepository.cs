using DataAccess.Model;
using Domain.IRepositories;
using DTO;
using System.Linq;

namespace DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private BagDbContext _bagDbContext;
        public UserRepository(BagDbContext bagDbContext)
        {
            _bagDbContext = bagDbContext;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            User user = new User
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Password = userDto.Password,
                Skype = userDto.Skype
            };

            var result = _bagDbContext.Add(user);
            _bagDbContext.SaveChanges();

            userDto.Id = result.Entity.Id;

            return userDto;
        }
        public bool DeleteUser(string email)
        {
            var user = _bagDbContext.User.FirstOrDefault(u=>u.Email == email);

            if (user == null)
                return false;

            _bagDbContext.Remove(user);
            _bagDbContext.SaveChanges();

            // TODO: какие варианты ошибок возможны? посмотреть на зависимость данных
            return true;
        }

        public UserDto GetUser(string email)
        {
            var user = _bagDbContext.User.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return null;

            var result = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Skype = user.Skype
            };

            return result;
        }

        public UserDto GetUser(string email, string password)
        {
            var user = _bagDbContext.User.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
                return null;

            var result = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Skype = user.Skype
            };

            return result;
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            var user = _bagDbContext.User.FirstOrDefault(u => u.Id == userDto.Id);

            if (user == null)
                return null;

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Skype = userDto.Skype;        

            _bagDbContext.Update(user);
            _bagDbContext.SaveChanges();

            return userDto;
        }      
    }
}
