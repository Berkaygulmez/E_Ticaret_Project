using E_Ticaret_Project.Models;
using FluentValidation;
using System.Data;
using System.Text.RegularExpressions;

namespace E_Ticaret_Project.ValidationRules
{
    public class RegisterValidator: AbstractValidator<Register>
    {

        public RegisterValidator()
        {
            RuleFor(user => user.NameSurname)
      .NotEmpty().WithMessage("İsim Soyisim boş olamaz.")
      .Length(2, 50).WithMessage("Kullanıcı adı 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(user => user.UserName)
           .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
           .Length(3, 20).WithMessage("Kullanıcı adı 3 ile 20 karakter arasında olmalıdır.");

            RuleFor(user => user.Mail)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(user => user.Password)
                  .NotEmpty().WithMessage("Şifre boş olamaz.")
                  .MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır.")
                  .Must(password =>
                      password != null &&
                      Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
                  ).WithMessage("Şifre en az 1 büyük harf, 1 küçük harf ve 1 sayı içermelidir.");

        }
    }
}
