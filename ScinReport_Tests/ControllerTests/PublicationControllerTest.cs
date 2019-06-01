using System;
using System.Collections.Generic;
using System.Text;
using ScinReport.Models;
using ScinReport.Controllers;
using Xunit;
using ScinReport.Models.Repositories;
using Moq;
using System.Linq;

namespace ScinReport_Tests.ControllerTests
{
    public class PublicationControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IPublicationRepositories> mock = new Mock<IPublicationRepositories>();
            mock.Setup(m => m.publications).Returns((new Publication[] {
new Publication  { Id = 1, TypeId = 12,Status="In Progress" },
                 new Publication { Id = 2, TypeId = 1,Status="In Progress" },
                 new Publication { Id = 3, TypeId = 13,Status="In Progress" },
                 new Publication { Id = 4, TypeId = 2,Status="In Progress" }
 }).AsQueryable<Publication>());
            PublicationsController controller = new PublicationsController(mock.Object);
            //controller.PageSize = 3;
             // Act
             IEnumerable<Publication> result = controller.List().ViewData.Model as IEnumerable<Publication>;
            // Assert
            Publication[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 4);
             Assert.Equal("In Progress", prodArray[0].Status);
            // Assert.Equal(13, prodArray[1].TypeId);
        }
    }
}
