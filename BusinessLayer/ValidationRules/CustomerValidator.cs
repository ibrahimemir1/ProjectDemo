using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
     public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Müşteri adı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Müşteri soyadı boş geçilemez");
            RuleFor(x => x.Customer_mail).NotEmpty().WithMessage("Müşteri maili boş geçilemez");
            RuleFor(x => x.Customer_password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("minimum 2 karakter girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("en fazla 50 karakter girişi yapabilirsiniz");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("minimum 2 karakter girişi yapınız");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("en fazla 50 karakter girişi yapabilirsiniz");
        }
    }
}
