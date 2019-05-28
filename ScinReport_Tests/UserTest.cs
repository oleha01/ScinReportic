using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class UserTest
    {
        //public string SurName { get; set; }
        //public string Name { get; set; }
        //public string Patronymic { get; set; } //По-Батькові
        //public string Position { get; set; }
        //public int Year_of_birth { get; set; }
        //public int Year_of_graduation { get; set; }//закінчення внз
        //public int Year_of_Protection { get; set; }//рік захисту
        //public string Academic_status { get; set; }//вчене звання
        //public int Year_of_Assignment { get; set; }//рік присвоєння вченого звання
        //public string Degree { get; set; }//ступінь
        [Fact]
        public void CanChangeUserName()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Name = "Iryna";
            Assert.Equal("Iryna", u.Name);
        }
        [Fact]
        public void CanChangeUserSurName()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.SurName = "Scorupska";
            Assert.Equal("Scorupska", u.SurName);
        }
    }
}
