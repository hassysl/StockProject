using FluentValidation;
using StockProject.Bussiness.Interfaces;
using StockProject.Common;
using StockProject.Dtos.UserDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class UserService : IUserService
    {
        private readonly IValidator<UserCreateDto> _createDtoValidator;
        private readonly IValidator<UserUpdateDto> _updateDtoValidator;
        private readonly IValidator<UserLoginDto> _loginDtoValidator;
        private readonly IUserRepository _repo;

        public UserService(IValidator<UserCreateDto> createDtoValidator, IValidator<UserUpdateDto> updateDtoValidator, IUserRepository repo, IValidator<UserLoginDto> loginValidator)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repo = repo;
            _loginDtoValidator = loginValidator;
        }

        public async Task<IResponse<UserCreateDto>> CreateAsync(UserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                //mapleme
                var mappedEntity = new User()
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Username = dto.Username,
                    Password = dto.Password,
                };

                await _repo.CreateAsync(mappedEntity);
                return new Response<UserCreateDto>(true, dto);
            }
            return new Response<UserCreateDto>(false, dto);
        }

        public async Task<IResponse<List<UserListDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var listDto = new List<UserListDto>();
            foreach (var item in data)
            {
                listDto.Add(new UserListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Username = item.Username,
                });
            }

            return new Response<List<UserListDto>>(true, listDto);
        }

        public async Task<IResponse<User>> GetByIdAsync<IDto>(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<User>(false, data);
            return new Response<User>(true, data);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response(false);
            _repo.Remove(data);
            return new Response(true);
        }

        public async Task<IResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _repo.GetByFilterAsync(x => x.Id == dto.Id); //.FindAsync(x);
                if (unchangedData == null)
                {
                    return new Response<UserUpdateDto>(false, dto);
                }
                var entity = new User()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Username = dto.Username,
                    Password = dto.Password,
                };
                _repo.Update(entity, unchangedData);
                return new Response<UserUpdateDto>(true, dto);
            }
            return new Response<UserUpdateDto>(false, dto);
        }

        public async Task<bool> CheckUserAsync(string username)
        {

            var user = await _repo.GetByFilterAsync(x => x.Username == username);
            if (user != null)
            {
                return true;
            }
            return false;

        }
        
    }
}
