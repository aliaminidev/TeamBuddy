using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingAttendance.Validators
{
    public class TrainingAttendanceDtoInterfaceValidator : AbstractValidator<ITrainingAttendanceDto>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly int _trainingSessionId;

        public TrainingAttendanceDtoInterfaceValidator(ITrainingSessionRepository trainingSessionRepository, int trainingSessionId)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _trainingSessionId = trainingSessionId;

            RuleFor(x => x.Status).
                NotNull().
                IsInEnum();

            RuleFor(x => x.AttendanceDuration).
                NotNull().
                GreaterThanOrEqualTo(0).
                MustAsync(async(entity, attendanceDuration, cancellationToken) =>
                {
                    return attendanceDuration <= await _trainingSessionRepository.GetDuration(_trainingSessionId);
                });

            RuleFor(x => x.Description).
                MaximumLength(5000);
        }
    }
}
