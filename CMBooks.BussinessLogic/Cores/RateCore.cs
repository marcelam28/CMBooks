using CMBooks.Models;
using CMBooks.DataLayer.Repositories;
using Deventure.BusinessLogic.Core;
using CMBooks.BusinessLogic.Models;
using CMBooks.Common.Response;

namespace CMBooks.BussinessLogic.Cores
{
    public class RateCore : BaseSinglePkCore<RateRepository, Rate, DataLayer.Rate>
    {
        public static Response Create(RateViewModel model)
        {
            var response = ResponseFactory.Success(ResponseCode.SuccessEntityCreated);
            if (model == null)
            {
                return ResponseFactory.Error(ResponseCode.ErrorInvalidInput);
            }

            var rate = model.CopyTo();

            var createdRate = Create(rate);

            if (createdRate == null)
            {
                response = ResponseFactory.Error(ResponseCode.ErrorCreatingEntity);
            }
            return response;
        }
    }
}
