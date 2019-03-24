using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using Deventure.BusinessLogic.Core;

namespace CMBooks.BussinessLogic.Cores
{
    public class UserCore : BaseSinglePkCore<UserRepository, User, DataLayer.User>
    {
    }
}
