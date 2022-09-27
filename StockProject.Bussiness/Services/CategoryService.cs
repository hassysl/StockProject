using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StockProject.Bussiness.Interfaces;
using StockProject.Bussiness.Mappings;
using StockProject.Common;
using StockProject.DataAccess.Context;
using StockProject.DataAccess.Interfaces;
using StockProject.DataAccess.Repositories;
using StockProject.Dtos.CategoryDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness
{
    public class CategoryService : ICategoryService
    {
        private readonly IValidator<CategoryCreateDto> _createDtoValidator;
        private readonly IValidator<CategoryUpdateDto> _updateDtoValidator;
        private readonly ICategoryRepository _repo;

        public CategoryService(IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator, ICategoryRepository repo , StockProjectContext context)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repo = repo;
        }

        public async Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                //mapleme
                var mappedEntity = new Category()
                {
                    Name = dto.Name,
                };

                await _repo.CreateAsync(mappedEntity);
                return new Response<CategoryCreateDto>(true, dto);
            }
            return new Response<CategoryCreateDto>(false, dto);
        }

        public async Task<IResponse<List<CategoryListDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var listDto = new List<CategoryListDto>();
            foreach (var item in data)
            {
                listDto.Add(new CategoryListDto
                {
                    Id = item.Id,
                    Name = item.Name,

                });
            }

            return new Response<List<CategoryListDto>>(true, listDto);
        }

        public async Task<IResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _repo.GetByFilterAsync(x => x.Id == dto.Id); //.FindAsync(x);
                if (unchangedData == null)
                {
                    return new Response<CategoryUpdateDto>(false, dto);
                }
                var entity = new Category()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                };
                _repo.Update(entity, unchangedData);
                return new Response<CategoryUpdateDto>(true, dto);
            }
            return new Response<CategoryUpdateDto>(false, dto);
        }


        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response(false);
            _repo.Remove(data);
            return new Response(true);
        }

        public async Task<IResponse<Category>> GetByIdAsync<IDto>(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<Category>(false, data);
            return new Response<Category>(true, data);
        }



    }
}
