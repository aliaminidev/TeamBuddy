using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance.Validators
{
    public class PlayerMatchPerformanceDtoInterfaceValidator : AbstractValidator<IPlayerMatchPerformanceDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public PlayerMatchPerformanceDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Status).
                NotNull().
                IsInEnum();

            RuleFor(x => x.AttendanceDuration).
                NotNull().
                GreaterThanOrEqualTo(0);

            RuleFor(x => x.MetricId).
                MustAsync(async (id, cancellationToken) =>
                {
                    if (id.HasValue)
                    {
                        return await _baseDataRepository.IsExist(id.Value);
                    }
                    else
                    {
                        return true;
                    }
                });

            RuleFor(x => x.Value).
                Must((entity, value) =>
                {
                    if (entity.MetricId.HasValue && value.HasValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });

            RuleFor(x => x.Description).
                MaximumLength(5000);
        }
    }
}
