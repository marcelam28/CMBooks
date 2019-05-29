using System;
using CMBooks.BussinessLogic.Cores;
using CMBooks.Models;
using CMBooks.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestRegister()
        {
            var user = new UserViewModel()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test.test@test.co",
                Password = Md5Helper.Hash("6178")
            };

            var createdUser = UserCore.Create(user);
            Assert.AreEqual(true, createdUser.Success);

            var createdUserDb = UserCore.GetSingle(_user => _user.Email == user.Email);
            Assert.AreEqual(true, createdUserDb != null);
            Assert.AreEqual(user.FirstName, createdUserDb.FirstName, "FirstName");
            Assert.AreEqual(user.LastName, createdUserDb.LastName, "LastName");
            Assert.AreEqual(user.Password, createdUserDb.Password, "Passwords");

            var deleteUserResponse = UserCore.Delete(createdUserDb);
            Assert.AreEqual(true, deleteUserResponse);
        }
    }
}
