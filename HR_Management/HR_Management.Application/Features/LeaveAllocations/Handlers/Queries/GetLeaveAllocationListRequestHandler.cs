using AutoMapper;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR_Management.Application.DTOs.LeaveAllocation;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler :
        IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
  
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository
            ,IMapper mapper)
        {
        
            this.leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

       

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveallocationlist=await leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveallocationlist);
        }
    }
}
