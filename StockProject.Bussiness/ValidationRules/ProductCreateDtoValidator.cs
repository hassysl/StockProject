using FluentValidation;
using StockProject.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.ValidationRules
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Stock).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
