using HR_Management_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence.Configuration.Entities
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.HasData(
                new LeaveRequest()
                {
                    Id = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Approved=true,
                    Cancelled=false,
                    DateRequested=DateTime.Now,
                    LeaveTypeId=1,
                    RequestComments="trierd"

                }, new LeaveRequest()
                {
                    Id = 2,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Approved = false,
                    Cancelled = false,
                    DateRequested = DateTime.Now,
                    LeaveTypeId = 2,
                    RequestComments="sick"

                }
                );
        }
    }
}
