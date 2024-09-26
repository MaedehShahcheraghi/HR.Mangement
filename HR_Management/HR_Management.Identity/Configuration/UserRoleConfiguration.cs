using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                    RoleId = "d43a6151-9461-4433-94fa-0b1170ee9f8d"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                    RoleId = "f7c5524f-719a-4239-a167-4a61c4bcff01"
                }
                );
        }
    }
}
