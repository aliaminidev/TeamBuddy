using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.BaseData.Validators
{
    public class UpdateBaseDataDtoValidator : AbstractValidator<UpdateBaseDataDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateBaseDataDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new BaseDataDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
