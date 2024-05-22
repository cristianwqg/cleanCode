using Pronabec.UseCases.Common.Bases;
using System;
using System.Collections.Generic;

namespace Pronabec.UseCases.Common.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public IEnumerable<BaseError> Errors { get; }
        public ValidationExceptionCustom()        
            : base("One or more validation failures")
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<BaseError> errors): this()
        {
            Errors = errors;
        }
    }
}
