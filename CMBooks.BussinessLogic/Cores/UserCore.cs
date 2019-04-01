using CMBooks.BusinessLogic.Models;
using CMBooks.Common.Response;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using Deventure.BusinessLogic.Core;

namespace CMBooks.BussinessLogic.Cores
{
    public class UserCore : BaseSinglePkCore<UserRepository, User, DataLayer.User>
    {
        public static Response Create(UserViewModel model)
        {
            var response = ResponseFactory.Success(ResponseCode.SuccessEntityCreated);
            if (model == null)
            {
                return ResponseFactory.Error(ResponseCode.ErrorInvalidInput);
            }

            var user = model.CopyTo();
            var createdUser = Create(user);
            if (createdUser == null)
            {
                response = ResponseFactory.Error(ResponseCode.ErrorCreatingEntity);
            }
            return response;
        }
    }
}
