using FluentValidation;
using GoCamping.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.BLL.Validations
{
    public class ContactValidation:AbstractValidator<ContactDto>
    {
        public ContactValidation() 
        {
            RuleFor(d => d.Name)
                      .NotNull().WithMessage("Name cannot be null.")
                      .NotEmpty().WithMessage("Name cannot be empty.");

            RuleFor(d => d.Email)
                .NotNull().WithMessage("Email cannot be null.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email is not in a valid format.");

            RuleFor(d => d.Message)
                .NotNull().WithMessage("Message cannot be null.")
                .NotEmpty().WithMessage("Message cannot be empty.");
        }
    }
}
