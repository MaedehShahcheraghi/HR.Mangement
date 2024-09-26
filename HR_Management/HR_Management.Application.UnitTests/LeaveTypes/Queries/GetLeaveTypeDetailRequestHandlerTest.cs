using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading.Tasks;
using HR_Management.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using System.Threading;
using Shouldly;
using HR_Management.Application.DTOs.LeaveType;

namespace HR_Management.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailRequestHandlerTest
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
        public GetLeaveTypeDetailRequestHandlerTest()
        {
            _leaveTypeRepositoryMock = MockLeaveTypeRepository.GetLeaveTypeReposittory();
            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper=mapperconfig.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler= new GetLeaveTypeListRequestHandler(_leaveTypeRepositoryMock.Object,_mapper);

            var result= await handler.Handle(new GetLeaveTypeListRequest(),CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(2);
        }
    }
    
}
