using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Match.Validators
{
    public class UpdateMatchDtoValidator : AbstractValidator<UpdateMatchDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateMatchDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new MatchDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
