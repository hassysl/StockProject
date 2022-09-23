using FluentValidation;
using StockProject.Bussiness.Extensions;
using StockProject.Bussiness.Mappings;
using StockProject.Common;
using StockProject.DataAccess.Context;
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
    public class CategoryService
    {
        private readonly IValidator<CategoryCreateDto> _createDtoValidator;
        private readonly IValidator<CategoryUpdateDto> _updateDtoValidator;
        private readonly Repository<Category> _repo;
        private readonly StockProjectContext _context;
        private readonly CategoryMapping _mapping;

        public CategoryService(IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator, Repository<Category> repo, StockProjectContext context, CategoryMapping mapping)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repo = repo;
            _context = context;
            _mapping = mapping;
        }

        public async Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                //mapleme
                var mappedEntity = _mapping.DtoToCategoryCreate(dto);
                
                await _repo.CreateAsync(mappedEntity);
                await _context.SaveChangesAsync();
                return new Response<CategoryCreateDto>(true, dto);
            }
            return new Response<CategoryCreateDto>(false, dto);
        }
    }
}
