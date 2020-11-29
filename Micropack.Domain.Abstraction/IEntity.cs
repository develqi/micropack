using System;

namespace Micropack.Domain.Abstraction
{
    //public interface IEntity<TKeyType> where TKeyType : struct
    //{
    //    TKeyType Id { get; set; }
    //}

    /// <summary>
    /// Entity marker
    /// </summary>
    public interface IEntity
    {
       
    }

    /// <summary>
    /// Guid primary key
    /// </summary>
    public interface IEntityGuid : IEntity
    {
        Guid Id { get; set; }   
    }

    /// <summary>
    /// Integer primary key
    /// </summary>
    public interface IEntityNumeric : IEntity
    {
        int Id { get; set; }
    }

    /// <summary>
    /// Long primary key
    /// </summary>
    public interface IEntityLongNumeric: IEntity
    {
        long Id { get; set; }
    }
}