using FluentValidation;
using GoCamping.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.BLL.Validations
{
    public class ProductValidation:AbstractValidator<ProductDto>
    {
        public ProductValidation() 
        {
            //Name
            RuleFor(d => d.Name).NotNull().WithMessage("The Name  area cannot be left empty.");
            RuleFor(d => d.Name).NotEmpty().WithMessage("The Name area cannot be left empty.");
            RuleFor(d => d.Name).MinimumLength(5).WithMessage("Please enter a minimum of 5 letters.");
            RuleFor(d => d.Name).MaximumLength(25).WithMessage("Please enter a maximum of 25 letters.");
            //Price
            RuleFor(d => d.Price).NotNull().WithMessage("The Price area cannot be left empty.");
            RuleFor(d => d.Price).NotEmpty().WithMessage("The Price area cannot be left empty.");
            RuleFor(d => d.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(d => d.Price).LessThan(10000).WithMessage("Price must be less than 10,000.");
            //Description
            RuleFor(d => d.Description).NotNull().WithMessage("The Description  area cannot be left empty.");
            RuleFor(d => d.Description).NotEmpty().WithMessage("The Description area cannot be left empty.");
            RuleFor(d => d.Description).MinimumLength(30).WithMessage("Please enter a minimum of 30 letters.");
            RuleFor(d => d.Description).MaximumLength(150).WithMessage("Please enter a maximum of 150 letters.");
            //Image
             RuleFor(d => d.Img)
            .NotNull().WithMessage("Image cannot be null.")
            .NotEmpty().WithMessage("Image cannot be empty.")
            .Must(d => d.Length <= 3).WithMessage("You can only upload up to 3 images.")
            .Must(d => d.Length >= 1).WithMessage("You must upload at least 1 image.");
            

        }
    }
}
