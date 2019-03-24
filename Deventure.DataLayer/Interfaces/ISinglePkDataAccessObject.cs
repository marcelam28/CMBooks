using System;

namespace Deventure.DataLayer.Interfaces
{
    public interface ISinglePkDataAccessObject : IDataAccessObject
    {
        Guid Id { get; set; }
    }
}