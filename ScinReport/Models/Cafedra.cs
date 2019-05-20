using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models
{
    public class Cafedra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultetId { get; set; }
        virtual public Facultet Facultet { get; set; }
    }
}
