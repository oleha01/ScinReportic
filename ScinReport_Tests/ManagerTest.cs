using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ScinReport.Models;
namespace ScinReport_Tests
{
    public class ManagerTest
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int UserId { get; set; }
        [Fact]
        public void CanChangeManagerName()
        {
            var u = new Manager { Id = 1,SurName="Burdeyna", Name = "Tania",Patronymic="Mykytina", UserId = 12 };
            u.Name = "Ira";
            Assert.Equal("Ira", u.Name);
        }
        [Fact]
        public void CanChangeManagerId()
        {
            var u = new Manager { Id = 1, SurName = "Burdeyna", Name = "Tania", Patronymic = "Mykytina", UserId = 12 };
            u.Id = 34;
            Assert.Equal(34, u.Id);
        }
        [Fact]
        public void CanChangeManagerSurName()
        {
            var u = new Manager { Id = 1, SurName = "Burdeyna", Name = "Tania", Patronymic = "Mykytina", UserId = 12 };
            u.SurName = "Burdeina";
            Assert.Equal("Burdeina", u.SurName);
        }
        [Fact]
        public void CanChangeManagerPatronymic()
        {
            var u = new Manager { Id = 1, SurName = "Burdeyna", Name = "Tania", Patronymic = "Mykytina", UserId = 12 };
            u.Patronymic = "Ivanivna";
            Assert.Equal("Ivanivna", u.Patronymic);
        }
        [Fact]
        public void CanChangeManagerUserId()
        {
            var u = new Manager { Id = 1, SurName = "Burdeyna", Name = "Tania", Patronymic = "Mykytina", UserId = 12 };
            u.UserId = 34;
            Assert.Equal(34, u.UserId);
        }
    }
}
