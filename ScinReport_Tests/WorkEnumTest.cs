using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class WorkEnumTest
    {
        [Fact]
        public void CanChangeWorkEnumId()
        {
            var u = new WorkEnum { Id = 3, Name="name"};
            u.Id = 4;
            Assert.Equal(4, u.Id);
        }
        [Fact]
        public void CanChangeWorkEnumName()
        {
            var u = new WorkEnum { Id = 3, Name="name" };
            u.Name = "Text";
            Assert.Equal("Text", u.Name);
        }
    }
}
