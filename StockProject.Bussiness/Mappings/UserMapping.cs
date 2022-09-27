using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public class UserMapping 
    {
        public UserCreateDto UserToDtoCreate(User user)
        {

            return new UserCreateDto()
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Password = user.Password,
            };
        }
        public User DtoToUserCreate(UserCreateDto userDto)
        {
            return new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Username = userDto.Username,
                Password = userDto.Password,
            };
        }

        public UserUpdateDto UserToDtoUpdate(User user)
        {
            return new UserUpdateDto()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Password = user.Password,
            };
        }
        public User DtoToUserUpdate(UserUpdateDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Username = userDto.Username,
                Password = userDto.Password,
            };
        }

        public UserListDto UsertoDtoList(User user)
        {

            return new UserListDto()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
            };
        }
        public User DtoToUserList(UserListDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Username = userDto.Username,
            };
        }
    }
}
