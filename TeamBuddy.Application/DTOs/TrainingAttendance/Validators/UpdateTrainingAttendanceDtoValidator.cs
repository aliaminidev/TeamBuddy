using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.DTOs.TrainingAttendance.Validators
{
    public class UpdateTrainingAttendanceDtoValidator : AbstractValidator<UpdateTrainingAttendanceDto>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly int _trainingSessionId;

        public UpdateTrainingAttendanceDtoValidator(ITrainingSessionRepository trainingSessionRepository, int trainingSessionId)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _trainingSessionId = trainingSessionId;

            RuleFor(x => x.Id).
                NotNull().
                GreaterThan(0);

            Include(new TrainingAttendanceDtoInterfaceValidator(_trainingSessionRepository, _trainingSessionId));
        }
    }
}
