using CMBooks.Models;
using CMBooks.DataLayer.Repositories;
using Deventure.BusinessLogic.Core;

namespace CMBooks.BussinessLogic.Cores
{
    public class RateCore : BaseSinglePkCore<RateRepository, Rate, DataLayer.Rate>
    {
    }
}
