using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.BaseData.Validators
{
    public class BaseDataDtoInterfaceValidator : AbstractValidator<IBaseDataDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public BaseDataDtoInterfaceValidator(IBaseDataRepository baseDataRepository)
        { 
            _baseDataRepository = baseDataRepository;

            RuleFor(x  => x.Name).
                NotNull().
                NotEmpty().
                MaximumLength(100);

            RuleFor(x => x.ParentId).
                GreaterThanOrEqualTo(0).
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

            RuleFor(x => x.Description).
                MaximumLength(1000);
        }
    }
}
