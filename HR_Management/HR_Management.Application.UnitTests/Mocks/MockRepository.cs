using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeReposittory()
        {
            var leavetypes = new List<LeaveType>()
            {
                new LeaveType()
                {
                    Id = 1,
                    Name = "test vacation"
                },
                new LeaveType()
                {
                    Id = 2,
                    Name = "test sick"
                }
            };
            var mockrepository = new Mock<ILeaveTypeRepository>();
            mockrepository.Setup(r => r.GetAll()).ReturnsAsync(leavetypes);
            mockrepository.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync(
                (LeaveType LeaveType) =>
                {
                    leavetypes.Add(LeaveType);
                    return LeaveType;
                });
            return mockrepository;
        }
                
    }
}
