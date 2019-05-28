using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class CafedraTest
    {
        
        [Fact]
        public void CanChangeCafedraName()
        {
            var u = new Cafedra { Id = 1, Name = "Math", FacultetId = 12 };
            u.Name = "MathAnaliz";
            Assert.Equal("MathAnaliz", u.Name);
        }
        [Fact]
        public void CanChangeCafedraId()
        {
            var u = new Cafedra { Id = 1, Name = "Ira", FacultetId = 12 };
            u.Id = 34;
            Assert.Equal(34, u.Id);
        }
        [Fact]
        public void CanChangeCafedraFacultetId()
        {
            var u = new Cafedra { Id = 1, Name = "Ira", FacultetId = 12 };
            u.FacultetId = 45;
            Assert.Equal(45, u.FacultetId);
        }
    }
}
