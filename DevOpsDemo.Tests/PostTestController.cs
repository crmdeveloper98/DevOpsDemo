using DevOpsDemo.Controllers;
using DevOpsDemo.Models;
using DevOpsDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace DevOpsDemo.Tests
{
    public class PostTestController
    {
        private PostRepository _repository;

        public PostTestController() => _repository = new PostRepository();


        [Fact]
        public void Test_Index_View_Result()
        {
            //Arrange
            var controller = new HomeController(null, _repository);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public void Test_Index_Return_Result()
        {
            //Arrange
            var controller = new HomeController(null, _repository);

            //Act
            var result = controller.Index();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Index_GetPosts_MatchData_Count()
        {
            //Arrange
            var controller = new HomeController(null,_repository);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(3, model.Count);
        }

        [Fact]
        public void Test_Index_GetPosts_MatchData_Post()
        {
            //Arrange
            var controller = new HomeController(null,_repository);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(101, model[0].PostId);
        }

        [Fact]
        public void Test_Index_GetPosts_MatchData_All()
        {
            //Arrange
            var controller = new HomeController(null,_repository);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<PostViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(3, model.Count);
            Assert.Equal(101, model[0].PostId);
            Assert.Equal("DevOps Demo Title 1", model[0].Title);
        }
    }
}
