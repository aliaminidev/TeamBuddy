using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TeamMember.Validators
{
    public class UpdateTeamMemberDtoValidator : AbstractValidator<UpdateTeamMemberDto>
    {
        public UpdateTeamMemberDtoValidator()
        {
            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new TeamMemberDtoInterfaceValidator());
        }
    }
}
