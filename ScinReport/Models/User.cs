using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ScinReport.Models
{
    public class User : IdentityUser
    {
        
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; } //По-Батькові
        public string Position { get; set; }
        public int Year_of_birth { get; set; }
        public int Year_of_graduation { get; set; }//закінчення внз
        public int Year_of_Protection { get; set; }//рік захисту
        public string Academic_status { get; set; }//вчене звання
        public int Year_of_Assignment { get; set; }//рік присвоєння вченого звання
        public string Degree { get; set; }//ступінь
    }
}
