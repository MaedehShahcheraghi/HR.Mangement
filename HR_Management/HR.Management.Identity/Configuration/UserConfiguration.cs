using HR.Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "Admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    FirstName = "Admin",
                    LastName = "Adminian",
                    PasswordHash = hasher.HashPassword(null, "P@swword1")
                },
                  new ApplicationUser()
                  {
                      Id = "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                      Email = "User@localhost.com",
                      NormalizedEmail = "USER@LOCALHOST.COM",
                      UserName = "User@localhost.com",
                      NormalizedUserName = "USER@LOCALHOST.COM",
                      FirstName = "System",
                      LastName = "User",
                      PasswordHash = hasher.HashPassword(null, "P@swword1")
                  }
                );
      
        }
    }
}
