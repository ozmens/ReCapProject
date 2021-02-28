using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
        }
    }
}
