using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;

namespace ScinReport_Tests
{
    public class AdminTest
    {
        
        [Fact]
        public void CanChangeAdminName()
        {
            var u = new Admin {Id=1, SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna",UserId=12 };
            u.Name = "Iryna";
            Assert.Equal("Iryna", u.Name);
        }
        [Fact]
        public void CanChangeAdminId()
        {
            var u = new Admin { Id = 1, SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", UserId = 12 };
            u.Id = 3;
            Assert.Equal(3, u.Id);
        }
        [Fact]
        public void CanChangeAdminSurName()
        {
            var u = new Admin { Id = 1, SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", UserId = 12 };
            u.SurName = "Burdeina";
            Assert.Equal("Burdeina", u.SurName);
        }
        [Fact]
        public void CanChangeAdminPatronymic()
        {
            var u = new Admin { Id = 1, SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", UserId = 12 };
            u.Patronymic = "Mykytivna";
            Assert.Equal("Mykytivna", u.Patronymic);
        }
        [Fact]
        public void CanChangeAdminUserId()
        {
            var u = new Admin { Id = 1, SurName = "Burdeina", Name = "Ira", Patronymic = "Mikitivna", UserId = 12 };
            u.UserId = 34;
            Assert.Equal(34, u.UserId);
        }
    }
}
