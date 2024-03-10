using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Service.Data;
using Service.ProjectService;

namespace UnitTests.Server
{
    [TestClass]
    public class ProjectUnitTest
    {
        private readonly Mock<IDataContext> mockDataContext = new Mock<IDataContext>();

        private readonly Mock<DbSet<Project>> mockDbSet = new Mock<DbSet<Project>>();

        [TestMethod]
        public void TestGetAllProject()
        {
            // arrange
            var dummyProjects = getListOfProjects();
            mockDbSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(dummyProjects.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(dummyProjects.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(dummyProjects.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(dummyProjects.AsQueryable().GetEnumerator());
            mockDataContext.Setup(_ => _.Projects).Returns(mockDbSet.Object);

            IProjectService projectService = new ProjectService(mockDataContext.Object);

            // act
            var actual = projectService.GetAllProjects();

            // assert
            Assert.AreEqual("First", actual[0].Name);
            Assert.AreEqual("Second", actual[1].Name);
            Assert.AreEqual("Third", actual[2].Name);
            Assert.AreEqual("Forth", actual[3].Name);
            Assert.AreEqual("Fifth", actual[4].Name);
        }

        private List<Project> getListOfProjects()
        {
            return new List<Project>
            {
                new Project
                {
                    Key = Guid.NewGuid(),
                    Name = "First",
                    Deadline = new DateTime(2010, 10, 10),
                },
                new Project
                {
                    Key = Guid.NewGuid(),
                    Name = "Third",
                    Deadline = new DateTime(2025, 4, 10, 13, 10, 5),
                },
                new Project
                {
                    Key = Guid.NewGuid(),
                    Name = "Fifth"
                },new Project
                {
                    Key = Guid.NewGuid(),
                    Name = "Forth",
                    Deadline = new DateTime(2099, 1, 1),
                },
                new Project
                {
                    Key = Guid.NewGuid(),
                    Name = "Second",
                    Deadline = new DateTime(2025, 4, 10, 12, 30, 0),
                }
            };
        }
    }
}