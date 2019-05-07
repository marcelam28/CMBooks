using CMBooks.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMBooks.BussinessLogic.Helpers
{
    public class DLtoModelsConvertor
    {
        public static BookViewModel ConvertBookDLIntoBookVM(DataLayer.Book bookDL)
        {
            if(bookDL == null)
            {
                return null;
            }

            var bookVM = new BookViewModel()
            {
                Id = bookDL.Id,
                Title = bookDL.Title,
                Description = bookDL.Description,
                Pages = bookDL.Pages,
                PublicationDate = bookDL.PublicationDate,
                Genre = bookDL.Genre,
                PictureUrl = bookDL.PictureUrl,
                Author = bookDL.Author
            };
            if (bookDL.Rates.Count > 0)
            {
                bookVM.Rate = Convert.ToInt32(bookDL.Rates.Select(t => t.Rate1).Average());
            }
            else
            {
                bookVM.Rate = 5;
            }

            return bookVM;
        }

        public static List<BookViewModel> ConvertBookDLIntoBookVM(IList<DataLayer.Book> bookDLList)
        {
            if (bookDLList == null)
            {
                return null;
            }

            List<BookViewModel> booksVMList = new List<BookViewModel>();
            foreach (var bookDL in bookDLList)
            {
                var bookVM = ConvertBookDLIntoBookVM(bookDL);
                booksVMList.Add(bookVM);
            }

            return booksVMList;
        }
    }
}
