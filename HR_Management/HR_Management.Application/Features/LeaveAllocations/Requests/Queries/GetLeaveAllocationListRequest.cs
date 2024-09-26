using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {

    }
}
