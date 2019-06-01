using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScinReport.Models
{
    public class WorkEnum
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
    }
}
