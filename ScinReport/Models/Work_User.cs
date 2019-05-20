using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models
{
    public class Work_User
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        virtual public Work Work { get; set; }
        public int UserId { get; set; }
        virtual public Teacher User { get; set; }
    }
}
