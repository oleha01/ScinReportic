using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class WorkUserTest
    {
        [Fact]
        public void CanChangeWorkUserId()
        {
            var u = new Work_User { Id = 3, PublicationId = 4, UserId = "5" };
            u.Id = 4;
            Assert.Equal(4, u.Id);
        }
        [Fact]
        public void CanChangeWorkUserPublicationId()
        {
            var u = new Work_User { Id = 3, PublicationId = 2, UserId = "5" };
            u.PublicationId = 4;
            Assert.Equal(4, u.PublicationId);
        }
        [Fact]
        public void CanChangeWorkUserUserId()
        {
            var u = new Work_User { Id = 3, PublicationId = 4, UserId = "5" };
            u.UserId = "6";
            Assert.Equal("6", u.UserId);
        }
    }
}
