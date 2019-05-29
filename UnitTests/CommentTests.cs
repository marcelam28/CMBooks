using System;
using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.Models;
using CMBooks.Web.Helpers;
using Deventure.DataLayer.EF.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void TestAddComment()
        {
            var comment = new CommentViewModel()
            {
                UserId = new Guid("AA60C4D9-C91D-46BE-92CE-0CF152E54BB6"),
                BookId = new Guid("4D2A54B9-6249-49A0-81B5-03EEF80552CC"),
                Comment1="Test Comment",
                AddedAt=DateTime.Now
            };

            var createdComment = CommentCore.Create(comment);
            Assert.AreEqual(true, createdComment.Success);

            var createdCommentDb = CommentCore.GetSingle(_comment => _comment.UserId == comment.UserId && _comment.BookId == comment.BookId && _comment.Comment1 == comment.Comment1);
            Assert.AreEqual(true, createdCommentDb != null);
            Assert.AreEqual(comment.UserId, createdCommentDb.UserId, "User");
            Assert.AreEqual(comment.BookId, createdCommentDb.BookId, "Book");
            Assert.AreEqual(comment.Comment1, createdCommentDb.Comment1, "Comment");

            var deleteCommentResponse = CommentCore.Delete(createdCommentDb);
            Assert.AreEqual(true, deleteCommentResponse);
        }
        [TestMethod]
        public void TestDeleteComment()
        {
            var comment = new CommentViewModel()
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("AA60C4D9-C91D-46BE-92CE-0CF152E54BB6"),
                BookId = new Guid("4D2A54B9-6249-49A0-81B5-03EEF80552CC"),
                Comment1 = "Test Comment for Delete",
                AddedAt = DateTime.Now
            };

            var createdComment = CommentCore.Create(comment);
            Assert.AreEqual(true, createdComment.Success);
            var result = CommentCore.Delete(comment.Id);
            Assert.AreEqual(true, result.Success);
            var CommentDb = CommentCore.GetSingle(_comment => _comment.Id ==comment.Id);
            Assert.AreEqual(true, CommentDb != null);
            Assert.AreEqual(EntityStatus.Deleted, CommentDb.Status);
        }



    }
}
