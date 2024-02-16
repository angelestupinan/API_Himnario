using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class PipelineValidationException : Exception
    {
        public List<string> Errors { get;}    

        public PipelineValidationException() :base("Se ha producido uno o mas errores de validacion")
        {

            Errors = new List<string>();
        }

        public PipelineValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
      
    }
}
