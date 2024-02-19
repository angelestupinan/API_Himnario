using Application.Features.Himnos.Command.CreateHimnosCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himno.Command.CreateHimnoCommand
{
    public class CreateHimnosCommandValidator : AbstractValidator<Himnos.Command.CreateHimnosCommand.CreateHimnoCommand>
    {
        public CreateHimnosCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                .MaximumLength(100).WithMessage("{PropertyName} no puede exceder los 100 caracteres");

            RuleFor(x => x.Lyrics)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío");


            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío");

        }
    }
}
