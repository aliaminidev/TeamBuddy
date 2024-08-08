using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TeamMember.Validators
{
    public class CreateTeamMemberDtoValidator : AbstractValidator<CreateTeamMemberDto>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamMemberDtoValidator(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;

            RuleFor(x => x.TeamId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _teamRepository.IsExist(id);
                });

            Include(new TeamMemberDtoInterfaceValidator());
        }
    }
}
