using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class UserTest
    {
        
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
        [Fact]
        public void CanChangeUserPatronymic()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Patronymic = "Ivanivna";
            Assert.Equal("Ivanivna", u.Patronymic);
        }
        [Fact]
        public void CanChangeUserPosition()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Position = "Developer";
            Assert.Equal("Developer", u.Position);
        }
        [Fact]
        public void CanChangeUserBirthYear()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_birth = 1998;
            Assert.Equal(1998, u.Year_of_birth);
        }
        [Fact]
        public void CanChangeUserAssigmentYear()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_Assignment = 2021;
            Assert.Equal(2021, u.Year_of_Assignment);
        }
        [Fact]
        public void CanChangeUserGraduationYear()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_graduation = 2045;
            Assert.Equal(2045, u.Year_of_graduation);
        }
        [Fact]
        public void CanChangeUserProtectionYear()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_Protection = 2031;
            Assert.Equal(2031, u.Year_of_Protection);
        }
        [Fact]
        public void CanChangeUserAcademicStatus()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Academic_status = "No found";
            Assert.Equal("No found", u.Academic_status);
        }
        [Fact]
        public void CanChangeUserDegree()
        {
            var u = new User { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Degree = "Not found";
            Assert.Equal("Not found", u.Degree);
        }

    }
}
