using System;
using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.Models;
using CMBooks.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void TestAddBook()
        {
            var book = new BookViewModel()
            {

                Title = "Test1",
                Author = "Test1Author",
                PublicationDate = DateTime.Now,
                Pages=259,
                Description="Description Test1",
                Genre="Romantic",
                PictureUrl= "https://images.pexels.com/photos/248797/pexels-photo-248797.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
            };

            var createdBook = BookCore.Create(book);
            Assert.AreEqual(true, createdBook.Success);

            var createdBookDb = BookCore.GetSingle(_book => _book.Title == book.Title && _book.PictureUrl==book.PictureUrl && _book.Author==book.Author);
            Assert.AreEqual(true, createdBookDb != null);
            Assert.AreEqual(book.Title, createdBookDb.Title, "Title");
            Assert.AreEqual(book.Author, createdBookDb.Author, "Author");
            Assert.AreEqual(book.Pages, createdBookDb.Pages, "Pages");
            Assert.AreEqual(book.Description, createdBookDb.Description, "Description");
            Assert.AreEqual(book.Genre, createdBookDb.Genre, "Genre");
            Assert.AreEqual(book.PictureUrl, createdBookDb.PictureUrl, "PictureUrl");

            var deleteBookResponse = BookCore.Delete(createdBookDb);
            Assert.AreEqual(true, deleteBookResponse);
        }
    }
}
