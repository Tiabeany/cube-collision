using CubeCollision.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CubeCollision.Application.Validators
{
    public class CubeValidation : AbstractValidator<Cube>
    {
        public CubeValidation()
        {
            RuleFor(cube => cube.Depth).NotNull().NotEqual(0).Must(depth => depth > 0);
            RuleFor(cube => cube.Height).NotNull().NotEqual(0).Must(depth => depth > 0);
            RuleFor(cube => cube.Width).NotNull().NotEqual(0).Must(depth => depth > 0);
            RuleFor(cube => cube.XPosition).NotNull().NotEqual(0).Must(depth => depth > 0);
            RuleFor(cube => cube.YPosition).NotNull().NotEqual(0).Must(depth => depth > 0);
            RuleFor(cube => cube.ZPosition).NotNull().NotEqual(0).Must(depth => depth > 0);
        }
    }
}
