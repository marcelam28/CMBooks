using System;

namespace Deventure.DataLayer.Interfaces
{
    public interface IDataAccessObjectWithName : ISinglePkDataAccessObject
    {
        string Name { get; set; }
    }
}