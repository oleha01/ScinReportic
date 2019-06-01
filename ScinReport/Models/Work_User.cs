using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models
{
    public class Work_User
    {
        public int Id { get; set; }
        public int PublicationId { get; set; }
        virtual public Publication Publication { get; set; }
        public string UserId { get; set; }
        virtual public User User { get; set; }
    }
}
