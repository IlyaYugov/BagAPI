using System;
using DataAccess.Model;
using Domain.IRepositories;
using DTO;
using System.Collections.Generic;
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
            User user = new User();
            UpdateUserFromDto(userDto,user);

            var result = _bagDbContext.Add(user);
            _bagDbContext.Save();

            userDto.Id = result.Entity.Id;

            return userDto;
        }
        public bool DeleteUser(int id)
        {
            var user = _bagDbContext.User.FirstOrDefault(u=>u.Id == id);
            //_bagDbContext.RemoveRange(user.UserMessengers);
            _bagDbContext.Remove(user);
            _bagDbContext.Save();

            // TODO: какие варианты ошибок возможны? посмотреть на зависимость данных
            return true;
        }

        public IEnumerable<string> GetMessangers(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int id)
        {
            var user = _bagDbContext.User.FirstOrDefault(u => u.Id == id);
            
            // TODO: доделать заполнение
            return new UserDto();
        }
        public UserDto UpdateUser(UserDto userDto)
        {
            var user = _bagDbContext.User.FirstOrDefault(u => u.Id == userDto.Id);
            UpdateUserFromDto(userDto, user);

            _bagDbContext.Update(user);
            _bagDbContext.Save();
            // TODO: обработка ошибки несуществования пользователя
            //if (user == null)  

            return userDto;
        }

        private void UpdateUserFromDto(UserDto userDto, User user)
        {
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Login = userDto.Login;
            user.PhoneNumber = userDto.PhoneNumber;
            //user.UserMessengers = userDto.Messengers.Select(m =>
            /* new UserMessenger
             {
                 Contact = m
             }).ToList();*/
        } 
    }
}
