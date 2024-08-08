using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance.Validators
{
    public class CreatePlayerMatchPerformanceDtoValidator : AbstractValidator<CreatePlayerMatchPerformanceDto>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreatePlayerMatchPerformanceDtoValidator(IMatchRepository matchRepository,
            ITeamMemberRepository teamMemberRepository, IBaseDataRepository baseDataRepository)
        {
            _matchRepository = matchRepository;
            _teamMemberRepository = teamMemberRepository;
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.MatchId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _matchRepository.IsExist(id);
                });

            RuleFor(x => x.PlayerId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _teamMemberRepository.IsPlayerExist(id);
                });

            Include(new PlayerMatchPerformanceDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
