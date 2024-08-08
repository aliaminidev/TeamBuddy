using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.Club.Validators
{
    public class CreateClubDtoValidator : AbstractValidator<CreateClubDto>
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateClubDtoValidator(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;

            Include(new ClubDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
