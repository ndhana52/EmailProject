using EmailProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailProject.Services
{
   public interface IEmailServices
    {
        Task SendTestEmail(UserEmailOptions useremailoptions);
        
    }
}
