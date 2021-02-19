using FluentValidation;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).NotEmpty();
        }
    }
}
