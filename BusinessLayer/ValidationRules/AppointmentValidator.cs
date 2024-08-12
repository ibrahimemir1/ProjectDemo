using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("Banka randevu tarihi boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Randevu açıklaması boş bırakılamaz.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Minimum 5 karakter giriniz");



        }
    }
}
