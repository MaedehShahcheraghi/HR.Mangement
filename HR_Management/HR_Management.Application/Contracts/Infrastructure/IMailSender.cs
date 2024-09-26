using HR_Management.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Contracts.Infrastructure
{
   public interface IMailSender
    {

        Task<bool> Send(Email eamil);
    }
}
