using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.BaseData.Validators
{
    public class CreateBaseDataDtoValidator : AbstractValidator<CreateBaseDataDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateBaseDataDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.DataType).
                NotNull().
                IsInEnum();

            Include(new BaseDataDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
