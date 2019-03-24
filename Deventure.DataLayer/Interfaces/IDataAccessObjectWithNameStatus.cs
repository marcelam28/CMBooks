using System;

namespace Deventure.DataLayer.Interfaces
{
    public interface IDataAccessObjectWithNameStatus : ISinglePkDataAccessObject
    {
        string Name { get; set; }
        int Status { get; set; }
    }
}