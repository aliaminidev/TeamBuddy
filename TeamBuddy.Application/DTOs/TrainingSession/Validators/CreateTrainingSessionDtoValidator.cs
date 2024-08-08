using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingSession.Validators
{
    public class CreateTrainingSessionDtoValidator : AbstractValidator<CreateTrainingSessionDto>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateTrainingSessionDtoValidator(ITeamRepository teamRepository, IBaseDataRepository baseDataRepository)
        {
            _teamRepository = teamRepository;
            _baseDataRepository = baseDataRepository;

            RuleFor(x => x.TeamId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _teamRepository.IsExist(id);
                });

            Include(new TrainingSessionDtoInterfaceValidator(_baseDataRepository));
        }
    }
}
