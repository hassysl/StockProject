using FluentValidation;
using StockProject.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.ValidationRules
{
    public class CategoryUpdateDtoVaildator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoVaildator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        }
    }
}
