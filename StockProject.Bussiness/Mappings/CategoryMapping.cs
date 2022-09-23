using StockProject.Dtos.CategoryDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public class CategoryMapping
    {
        public CategoryCreateDto CategoryToDtoCreate(Category category)
        {
            return new CategoryCreateDto()
            {
                Name = category.Name,
            };
        }
        public Category DtoToCategoryCreate (CategoryCreateDto categoryDto)
        {
            return new Category()
            {
                Name = categoryDto.Name,
            };
        }

        public CategoryUpdateDto CategoryToDtoUpdate(Category category)
        {
            return new CategoryUpdateDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
        public Category DtoToCategoryUpdate(CategoryUpdateDto categoryDto)
        {
            return new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
        }

        public CategoryListDto CategoryToDtoList(Category category)
        {
            return new CategoryListDto()
            {
                Id = category.Id,
                Name = category.Name,

            };
        }
        public Category DtoToCategoryList(CategoryListDto categoryDto)
        {
            return new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
        }

    }
}
