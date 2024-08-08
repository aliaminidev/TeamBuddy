using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingAttendance.Validators
{
    public class CreateTrainingAttendanceDtoValidator : AbstractValidator<CreateTrainingAttendanceDto>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly int _trainingSessionId;

        public CreateTrainingAttendanceDtoValidator(ITrainingSessionRepository trainingSessionRepository,
            ITeamMemberRepository teamMemberRepository, int trainingSessionId)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _teamMemberRepository = teamMemberRepository;
            _trainingSessionId = trainingSessionId;

            RuleFor(x => x.TraningSessionId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _trainingSessionRepository.IsExist(id);
                });
            
            RuleFor(x => x.PlayerId).
                NotNull().
                GreaterThan(0).
                MustAsync(async (id, cancellationToken) =>
                {
                    return await _teamMemberRepository.IsExist(id);
                });

            Include(new TrainingAttendanceDtoInterfaceValidator(_trainingSessionRepository, _trainingSessionId));
        }
    }
}
