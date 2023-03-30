using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GoCamping.DAL.DBModel
{
    public class AppUser:IdentityUser
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
