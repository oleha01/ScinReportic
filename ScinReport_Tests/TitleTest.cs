using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class TitleTest
    {
        
        [Fact]
        public void CanChangeTitleText()
        {
            var u = new Title {  Id=1,Text="Cursova",CafedraId=1,Years="2019"};
            u.Text = "Cursova written by Iryna";
            Assert.Equal("Cursova written by Iryna", u.Text);
        }
        [Fact]
        public void CanChangeTitleId()
        {
            var u = new Title { Id = 1, Text = "Cursova", CafedraId = 1, Years = "2019" };
            u.Id = 3;
            Assert.Equal(3, u.Id);
        }
        [Fact]
        public void CanChangeTitleCafedraId()
        {
            var u = new Title { Id = 1, Text = "Cursova", CafedraId = 1, Years = "2019" };
            u.CafedraId = 3;
            Assert.Equal(3, u.CafedraId);
        }
        [Fact]
        public void CanChangeTitleYears()
        {
            var u = new Title { Id = 1, Text = "Cursova", CafedraId = 1, Years = "2019" };
            u.Years = "2018-2019";
            Assert.Equal("2018-2019", u.Years);
        }
    }
}
