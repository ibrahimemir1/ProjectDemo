using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator() 
        {
           
            RuleFor(x => x.Branch_Id).NotEmpty().WithMessage("çalışan şubesi boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Minimum 2 karakter giriniz");
            RuleFor(x => x.Surname).MinimumLength(5).WithMessage("Minimum 2 karakter giriniz");
        }
        
    }
}
