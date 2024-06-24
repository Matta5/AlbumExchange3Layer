using Albums3Layer.BLL;
using Albums3Layer.BBL.Models;
using BLL.Interfaces;

namespace Albums3Layer.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private IUserRepository _fakeUserRepository;

        [TestInitialize]
        public void Setup()
        {
            _fakeUserRepository = new FakeUserRepository();
            _userService = new UserService(_fakeUserRepository);
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
