using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class FacultedTest
    {
        [Fact]
        public void CanChangeFacultedName()
        {
            var u = new Facultet{ Id = 1, Name = "Math" };
            u.Name = "Math&Informatic";
            Assert.Equal("Math&Informatic", u.Name);
        }
        [Fact]
        public void CanChangeCafedraId()
        {
            var u = new Facultet { Id = 1, Name = "Math"};
            u.Id = 34;
            Assert.Equal(34, u.Id);
        }
    }
}
