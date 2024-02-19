using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Himnos.Command.DeleteHimnoCommand
{
    internal class DeleteHimnoCommandValidator : AbstractValidator<DeleteHimnoCommand>
    {
        public DeleteHimnoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.");
        }
    }
}
