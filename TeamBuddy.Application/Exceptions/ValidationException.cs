using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace TeamBuddy.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        private readonly ValidationResult _validationResult;
        public List<string> Errors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            _validationResult = validationResult;
            Errors = new List<string>();

            foreach(var error in _validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
