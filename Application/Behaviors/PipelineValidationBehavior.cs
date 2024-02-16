﻿using Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class PipelineValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public PipelineValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request, cancellationToken)));
                var failures = validationResult.SelectMany(x => x.Errors).Where(x => x !=null).ToList();

                if(failures.Count != 0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }
             return await next();
        }
    }
}
