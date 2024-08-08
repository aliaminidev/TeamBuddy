using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Team.Validators
{
    public class TeamDtoInterfaceValidator : AbstractValidator<ITeamDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public TeamDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Name).
                NotNull().
                NotEmpty().
                MaximumLength(100);

            RuleFor(x => x.StadiumId).
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
        }
    }
}
