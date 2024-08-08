using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Queries
{
    public class GetTrainingAttendanceListRequestHandler : IRequestHandler<GetTrainingAttendanceListRequest, List<TrainingAttendanceDto>>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;

        public GetTrainingAttendanceListRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
        }

        public async Task<List<TrainingAttendanceDto>> Handle(GetTrainingAttendanceListRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendanceList = await _trainingAttendanceRepository.GetAll();
            return _mapper.Map<List<TrainingAttendanceDto>>(trainingAttendanceList);
        }
    }
}
