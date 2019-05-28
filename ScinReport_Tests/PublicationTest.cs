using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class PublicationTest
    {
        
        [Fact]
        public void CanChangePublicationTypeId()
        {
            var u = new Publication { Id = 1, TypeId = 12,Status="In Progress" };
            u.TypeId = 2;
            Assert.Equal(2, u.TypeId);
        }
        [Fact]
        public void CanChangePublicationId()
        {
            var u = new Publication { Id = 1, TypeId = 12, Status = "In Progress" };
            u.Id = 34;
            Assert.Equal(34, u.Id);
        }
        [Fact]
        public void CanChangePublicationStatus()
        {
            var u = new Publication { Id = 1, TypeId = 12, Status = "In Progress" };
            u.Status = "Comleted";
            Assert.Equal("Comleted", u.Status);
        }
    }
}
