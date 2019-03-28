using CMBooks.BusinessLogic.Models;
using CMBooks.Common.Response;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using Deventure.BusinessLogic.Core;
using Deventure.DataLayer.EF.Enums;

namespace CMBooks.BussinessLogic.Cores
{
    public class BookCore : BaseSinglePkCore<BookRepository,Book,DataLayer.Book>
    {
        public static Response Create(BookViewModel model)
        {
            var response = ResponseFactory.Success(ResponseCode.SuccessEntityCreated);
            if (model == null)
            {
                return ResponseFactory.Error(ResponseCode.ErrorInvalidInput);
            }

            var book = model.CopyTo();
            book.Status = EntityStatus.Active;
            var createdBook = Create(book);
            if (createdBook == null)
            {
                response = ResponseFactory.Error(ResponseCode.ErrorCreatingEntity);
            }
            return response;
        }
    }
}
