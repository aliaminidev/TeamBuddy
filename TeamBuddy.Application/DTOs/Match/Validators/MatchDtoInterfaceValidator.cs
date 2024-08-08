using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Match.Validators
{
    public class MatchDtoInterfaceValidator : AbstractValidator<IMatchDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public MatchDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.OpponentId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _baseDataRepository.IsExist(id);
                });

            RuleFor(x => x.Date).
                NotNull().
                LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.VenueId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _baseDataRepository.IsExist(id);
                });

            RuleFor(x => x.Result).
                NotNull().
                IsInEnum();

            RuleFor(x => x.Type).
                NotNull().
                IsInEnum();

            RuleFor(x => x.Description).
                MaximumLength(5000);
        }
    }
}
