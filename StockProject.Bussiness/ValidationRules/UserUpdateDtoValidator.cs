using FluentValidation;
using StockProject.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.ValidationRules
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Adınız 20 karakterden fazla olamaz");
            RuleFor(x => x.Name).MaximumLength(3).WithMessage("Adınız 3 karakterden az olamaz");

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Soyadınız 20 karakterden fazla olamaz");
            RuleFor(x => x.Surname).MaximumLength(3).WithMessage("Soyadınız 2 karakterden az olamaz");

            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("Kullanıcı adınız 50 karakterden fazla olamaz");
            RuleFor(x => x.Username).MaximumLength(8).WithMessage("Kullanıcı adınız 8 karakterden az olamaz");

            RuleFor(x => x.PasswordCheck).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Parolanız 50 karakterden fazla olamaz");
            RuleFor(x => x.Password).MaximumLength(8).WithMessage("Parolanız 8 karakterden az olamaz");

            RuleFor(x => x.PasswordCheck).NotEmpty();
            RuleFor(x => x.PasswordCheck).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");
        }
    }
}
