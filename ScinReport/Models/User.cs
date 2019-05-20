using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ScinReport.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        virtual public Teacher Teacher { get; set; }
        virtual public Admin Admin { get; set; }
        virtual public Manager Manager { get; set; }
       
    }
}
