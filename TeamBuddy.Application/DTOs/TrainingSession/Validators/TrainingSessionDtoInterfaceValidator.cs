using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingSession.Validators
{
    public class TrainingSessionDtoInterfaceValidator : AbstractValidator<ITrainingSessionDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public TrainingSessionDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.DateTime).
                NotNull().
                LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.LocationId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _baseDataRepository.IsExist(id);
                });

            RuleFor(x => x.Duration).
                NotNull().
                GreaterThan(0);
        }
    }
}
