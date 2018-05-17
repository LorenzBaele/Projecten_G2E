//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using DotNetG2E.Controllers;
//using DotNetG2E.Views;
//using DotNetG2E.Models.Domain;
//using Xunit;

//namespace DotNetG2e.Tests.LeerkrachtControllerTests
//{
//    public class HomeControllerTests
//    {
//        [Fact]
//        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
//        {
//            // Arrange
//            var mockRepoSessie = new Mock<ISessieRepository>();
//            var mockRepoLeerkracht = new Mock<ILeerkrachtRepository>();
//            mockRepoSessie.Setup(repo => repo.Returns(Task.FromResult(GetTestSessions()));
//            var controller = new LeerkrachtController(mockRepoLeerkracht.Object, mockRepoSessie.Object);

//            // Act
//            var result = await controller.Index();

//            // Assert
//            var viewResult = Assert.IsType<ViewResult>(result);
//            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
//                viewResult.ViewData.Model);
//            Assert.Equal(2, model.Count());
//        }

//        private List<BrainstormSession> GetTestSessions()
//        {
//            var sessions = new List<BrainstormSession>();
//            sessions.Add(new BrainstormSession()
//            {
//                DateCreated = new DateTime(2016, 7, 2),
//                Id = 1,
//                Name = "Test One"
//            });
//            sessions.Add(new BrainstormSession()
//            {
//                DateCreated = new DateTime(2016, 7, 1),
//                Id = 2,
//                Name = "Test Two"
//            });
//            return sessions;
//        }
//    }
//}
