using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TeamMember.Validators
{
    public class TeamMemberDtoInterfaceValidator : AbstractValidator<ITeamMemberDto>
    {
        public TeamMemberDtoInterfaceValidator()
        {
            RuleFor(x => x.MemberType).
                NotNull().
                IsInEnum();
        }
    }
}
