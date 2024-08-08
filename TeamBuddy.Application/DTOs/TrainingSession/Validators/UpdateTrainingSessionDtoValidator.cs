using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingSession.Validators
{
    public class UpdateTrainingSessionDtoValidator : AbstractValidator<UpdateTrainingSessionDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateTrainingSessionDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new TrainingSessionDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
