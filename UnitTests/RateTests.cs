using System;
using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.Models;
using CMBooks.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RateTests
    {
        [TestMethod]
        public void TestAddRate()
        {
            var rate = new RateViewModel()
            {
                UserId = new Guid("AA60C4D9-C91D-46BE-92CE-0CF152E54BB6"),
                BookId = new Guid("4D2A54B9-6249-49A0-81B5-03EEF80552CC"),
                Rate1=5
            };

            var createdRate = RateCore.Create(rate);
            Assert.AreEqual(true, createdRate.Success);

            var createdRateDb = RateCore.GetSingle(_rate => _rate.UserId == rate.UserId && _rate.BookId == rate.BookId && _rate.Rate1 == rate.Rate1);
            Assert.AreEqual(true, createdRateDb != null);
            Assert.AreEqual(rate.UserId, createdRateDb.UserId, "User");
            Assert.AreEqual(rate.BookId, createdRateDb.BookId, "Book");
            Assert.AreEqual(rate.Rate1, createdRateDb.Rate1, "Rate");

            var deleteRateResponse = RateCore.Delete(createdRateDb);
            Assert.AreEqual(true, deleteRateResponse);
        }
    }
}
