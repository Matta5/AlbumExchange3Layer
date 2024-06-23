using System;
using System.Collections.Generic;
using Albums3Layer.BBL.Models;
using Albums3Layer.BLL;
using BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Albums3Layer.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private Mock<IUserRepository> _userRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }


        [TestMethod]
        public void CreateUser_WithValidPassword_ShouldNotThrowException()
        {
            var user = new User { username = "testuser", password = "ValidPass123" };

            try
            {
                _userService.CreateUser(user);
            }
            catch (Exception)
            {
                Assert.Fail("Expected no exception, but got one.");
            }
        }

        [TestMethod]
        public void CreateUser_WithInvalidPassword_ShouldReturnErrorMessage()
        {
            var user = new User { username = "testuser", password = "invalidpass" };
            string validationResult = _userService.IsValidPassword(user.password);

            Assert.IsNotNull(validationResult, "Expected an error message, but got null.");
        }

        [TestMethod]
        public void EditUser_WithValidPassword_ShouldNotThrowException()
        {
            var user = new User { user_id = 1, username = "testuser", password = "ValidPass123" };

            try
            {
                _userService.EditUser(user);
            }
            catch (Exception)
            {
                Assert.Fail("Expected no exception, but got one.");
            }
        }

        [TestMethod]
        public void CreateUser_WithValidPassword_ShouldNotReturnErrorMessage()
        {
            var user = new User { username = "testuser", password = "ValidPass123" };
            string validationResult = _userService.IsValidPassword(user.password);

            Assert.IsNull(validationResult, "Expected no error message, but got one.");
        }

    }
}
