using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Responses;
using HR_Management_Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMailSender _mailSender;

        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository,IMailSender mailSender)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _mailSender = mailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            request.LeaveRequestDto.DateRequested = DateTime.UtcNow;
            var Response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                Response.Success = false;
                Response.Message = "Creation Failed";
                Response.ErrorMessage = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = mapper.Map<LeaveRequest>(request.LeaveRequestDto);
                leaveRequest = await leaveRequestRepository.Add(leaveRequest);
                Response.Success = true;
                Response.Message = "Creation Success";
                Response.Id = leaveRequest.Id;

                //var email = new Email()
                //{
                //    To = "maedeh.shahcheraghi1384@gmail.com",
                //    Subject = "Leave Request Submited",
                //    Body = $"your Leave Request For {request.LeaveRequestDto.StartDate}"
                //    + $"To {request.LeaveRequestDto.EndDate} Has Been Submited"
                //};

                //try
                //{
                //    await _mailSender.Send(email);
                //}
                //catch (Exception)
                //{

                //    throw;
                //}
            }
            
         
            return  Response;
        }
    }
}
