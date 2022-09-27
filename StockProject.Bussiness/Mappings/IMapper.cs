using StockProject.Dtos.CategoryDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public interface IMapping
    {
        CategoryCreateDto CategoryToDtoCreate(Category category);

        Category DtoToCategoryCreate(CategoryCreateDto categoryDto);


        CategoryUpdateDto CategoryToDtoUpdate(Category category);

        Category DtoToCategoryUpdate(CategoryUpdateDto categoryDto);

        CategoryListDto CategoryListToDtoList(List<Category> category);

        Category DtoToCategoryList(CategoryListDto categoryDto);
        
    }
}
