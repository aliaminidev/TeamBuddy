using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Club.Validators
{
    public class UpdateClubDtoValidator : AbstractValidator<UpdateClubDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateClubDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new ClubDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
