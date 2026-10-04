using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // Arrange
            var classMock = new Mock<IRepository<Class>>();
            var dayMock = new Mock<IRepository<Day>>();

            var controller = new HomeController(
                classMock.Object,
                dayMock.Object);

            // Act
            var result = controller.Index(0);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}