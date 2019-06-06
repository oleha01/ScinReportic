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
            var u = new Work_User { Id = 3, WorkId = 4, UserId = 5 };
            u.Id = 4;
            Assert.Equal(4, u.Id);
        }
        [Fact]
        public void CanChangeWorkUserWorkId()
        {
            var u = new Work_User { Id = 3, WorkId = 4, UserId = 5 };
            u.WorkId = 4;
            Assert.Equal(4, u.WorkId);
        }
        [Fact]
        public void CanChangeWorkUserUserId()
        {
            var u = new Work_User { Id = 3, WorkId = 4, UserId = 5 };
            u.UserId = 4;
            Assert.Equal(4, u.UserId);
        }
    }
}
