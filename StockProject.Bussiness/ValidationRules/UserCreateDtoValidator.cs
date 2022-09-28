using FluentValidation;
using StockProject.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.ValidationRules
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Adınız 20 karakterden fazla olamaz");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Adınız 1 karakterden az olamaz");

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Soyadınız 20 karakterden fazla olamaz");
            RuleFor(x => x.Surname).MinimumLength(1).WithMessage("Soyadınız 1 karakterden az olamaz");

            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("Kullanıcı adınız 50 karakterden fazla olamaz");
            RuleFor(x => x.Username).MinimumLength(1).WithMessage("Kullanıcı adınız 1 karakterden az olamaz");

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Parolanız 50 karakterden fazla olamaz");
            RuleFor(x => x.Password).MinimumLength(1).WithMessage("Parolanız 1 karakterden az olamaz");
            RuleFor(x => x.PasswordCheck).NotEmpty();

            RuleFor(x => x.PasswordCheck).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");

        }
    }
}
