using DataModel.Entities;
using Facade.Project;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Service.ProjectService;

namespace UnitTests.Controller
{
    [TestClass]
    public class ProjectUnitTest
    {
        private readonly Mock<IProjectService> mockProjectService = new Mock<IProjectService>();

        [DataTestMethod]
        [DataRow("Test 1", "10/03/2025")]
        [DataRow("Test project number two, a pproject with a really really REALLY long name ... and even some unique symbols: _!#¤$$%\n\t123}]Øå<*\n", "15/01/2030 12:45:30")]
        [DataRow("T3", null)]
        public void TestCreateProject(string projectName, string? formattedProjectDeadline)
        {
            // arrange
            var projectKey = Guid.NewGuid();
            DateTime? projectDeadline = getProjectDeadline(formattedProjectDeadline);
            CreateProjectRequest request = getCreateProjectRequestRequest(projectName, projectDeadline);
            Project project = getExpectedProject(projectKey, projectName, projectDeadline);
            mockProjectService.Setup(_ => _.CreateProject(It.IsAny<CreateProjectDTO>())).Returns(project);
            ProjectController projectController = new ProjectController(mockProjectService.Object);

            // act
            var actionResult = projectController.CreateProject(request);

            // assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            var result = (OkObjectResult)actionResult.Result;
            var actual = (CreateProjectResponse)result.Value;
            Assert.IsNotNull(actual.ProjectKey);
            Assert.AreEqual(actual.ProjectKey, projectKey);
        }

        private static DateTime? getProjectDeadline(string? formattedProjectDeadline)
        {
            return string.IsNullOrEmpty(formattedProjectDeadline) ? null : DateTime.Parse(formattedProjectDeadline);
        }

        private static Project getExpectedProject(Guid projectKey, string projectName, DateTime? projectDeadline)
        {
            return new Project
            {
                Key = projectKey,
                Name = projectName,
                Deadline = projectDeadline,
            };
        }

        private static CreateProjectRequest getCreateProjectRequestRequest(string projectName, DateTime? projectDeadline)
        {
            return new CreateProjectRequest()
            {
                Name = projectName,
                Deadline = projectDeadline
            };
        }

        [DataTestMethod]
        [DataRow("6153a0ca-24d9-47a9-bce3-68db6daf4c84", "Test 1", "10/03/2025")]
        [DataRow("E6ED87DB-05E4-4F98-A304-69CD199A2A89", "Test number 2", "15/01/2030 12:45:30")]
        [DataRow("312749c9-3ddd-43ee-98c7-9e655369c02a", "T3", null)]
        public void TestGetProject(string formattedProjectKey, string projectName, string? formattedProjectDeadline)
        {
            // arrange
            Guid projectKey = Guid.Parse(formattedProjectKey);
            var projectDeadline = getProjectDeadline(formattedProjectDeadline);
            Project project = getExpectedProject(projectKey, projectName, projectDeadline);

            mockProjectService.Setup(_ => _.GetProject(projectKey)).Returns(project);
            ProjectController projectController = new ProjectController(mockProjectService.Object);

            // act
            var actionResult = projectController.GetProject(projectKey);

            // assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            var result = (OkObjectResult)actionResult.Result;
            var actual = (ProjectExternal)result.Value;
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Name, projectName);
            Assert.AreEqual(actual.Deadline, projectDeadline);
        }
    }
}
