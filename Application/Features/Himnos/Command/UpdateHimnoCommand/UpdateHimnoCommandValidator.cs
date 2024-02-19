using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Command.UpdateHimnoCommand
{
    public class UpdateHimnoCommandValidator : AbstractValidator<UpdateHimnoCommand>
    {
        public UpdateHimnoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.");

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
