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
        [DataRow("Password123", true)]
        [DataRow("password123", false)]
        [DataRow("PASSWORD123", true)]
        [DataRow("1234567890", false)]
        [DataRow("Password", true)]
        [DataRow("password", false)]
        public void IsValidPassword_ShouldReturnExpectedResult(string password, bool expected)
        {
            var result = _userService.IsValidPassword(password);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateUser_WithValidPassword_ShouldNotThrowException()
        {
            var user = new User { Username = "testuser", Password = "ValidPass123" };

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
        public void CreateUser_WithInvalidPassword_ShouldThrowException()
        {
            var user = new User { Username = "testuser", Password = "invalidpass" };

            Assert.ThrowsException<ArgumentException>(() => _userService.CreateUser(user));
        }

        [TestMethod]
        public void EditUser_WithValidPassword_ShouldNotThrowException()
        {
            var user = new User { Id = 1, Username = "testuser", Password = "ValidPass123" };

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
        public void EditUser_WithInvalidPassword_ShouldThrowException()
        {
            var user = new User { Id = 1, Username = "testuser", Password = "invalidpass" };

            Assert.ThrowsException<ArgumentException>(() => _userService.EditUser(user));
        }
    }
}
