using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CafedraId { get; set; }
        virtual public Cafedra Cafedra { get; set; }
        public string Years { get; set; }
    }
}
