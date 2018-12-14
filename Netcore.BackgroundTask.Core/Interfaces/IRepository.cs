using Netcore.BackgroundTask.Core.Entities;
using System;
namespace Netcore.BackgroundTask.Core.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
