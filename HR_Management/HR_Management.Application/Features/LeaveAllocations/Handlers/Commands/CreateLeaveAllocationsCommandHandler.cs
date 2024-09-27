using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocation.Validators;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Responses;
using System.Linq;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationsCommandHandler
        : IRequestHandler<CreateLeaveAllocationsCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationsCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ErrorMessage=validationResult.Errors.Select(e=> e.ErrorMessage).ToList();
                response.Message = "creation failed";
                

            }
             

            var leaveAllocations = mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
            leaveAllocations = await leaveAllocationRepository.Add(leaveAllocations);
            response.Success=true;
            response.Message = "creation sucessed";
            response.Id= leaveAllocations.Id;
            return response;
        }
    }
}
