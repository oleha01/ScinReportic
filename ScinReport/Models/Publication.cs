using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        virtual public WorkEnum Type { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
        public bool IfShared { get; set; }
    }
}
