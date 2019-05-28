using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class TeacherTest
    {
        [Fact]
        public void CanChangeTeacherName()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Name = "Iryna";
            Assert.Equal("Iryna", u.Name);
        }
        [Fact]
        public void CanChangeTeacherSurName()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.SurName = "Scorupska";
            Assert.Equal("Scorupska", u.SurName);
        }
        [Fact]
        public void CanChangeTeacherPatronymic()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Patronymic = "Ivanivna";
            Assert.Equal("Ivanivna", u.Patronymic);
        }
        [Fact]
        public void CanChangeTeacherPosition()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Position = "Developer";
            Assert.Equal("Developer", u.Position);
        }
        [Fact]
        public void CanChangeTeacherBirthYear()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_birth = 1998;
            Assert.Equal(1998, u.Year_of_birth);
        }
        [Fact]
        public void CanChangeTeacherAssigmentYear()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_Assignment = 2021;
            Assert.Equal(2021, u.Year_of_Assignment);
        }
        [Fact]
        public void CanChangeTeacherGraduationYear()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_graduation = 2045;
            Assert.Equal(2045, u.Year_of_graduation);
        }
        [Fact]
        public void CanChangeTeacherProtectionYear()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Year_of_Protection = 2031;
            Assert.Equal(2031, u.Year_of_Protection);
        }
        [Fact]
        public void CanChangeTeacherAcademicStatus()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Academic_status = "No found";
            Assert.Equal("No found", u.Academic_status);
        }
        [Fact]
        public void CanChangeTeacherDegree()
        {
            var u = new Teacher { SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", Position = "Student", Year_of_birth = 1999, Year_of_Assignment = 2025, Year_of_graduation = 2022, Year_of_Protection = 2026, Academic_status = "None", Degree = "None" };
            u.Degree = "Not found";
            Assert.Equal("Not found", u.Degree);
        }
    }
}
