using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Club.Validators
{
    public class ClubDtoInterfaceValidator : AbstractValidator<IClubDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public ClubDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Name).
                NotNull().
                NotEmpty().
                MaximumLength(100);

            RuleFor(x => x.FoundedDate).
                NotNull().
                LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ProvinceId).
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

            RuleFor(x => x.CityId).
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
