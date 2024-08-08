using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance.Validators
{
    public class UpdatePlayerMatchPerformanceDtoValidator : AbstractValidator<UpdatePlayerMatchPerformanceDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdatePlayerMatchPerformanceDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new PlayerMatchPerformanceDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
