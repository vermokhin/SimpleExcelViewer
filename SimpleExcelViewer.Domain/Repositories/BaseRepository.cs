using SimpleExcelViewer.Domain.Models;
using System;

namespace SimpleExcelViewer.Domain.Repositories
{
    /// <summary>
    /// Abstract implementation of <see cref="IRepository{T, TId}"/>
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TId"><see cref="T.Id"/></typeparam>
    public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : class, IModel<TId>
    {
        public BaseRepository()
        {
        }

        public T DeletedById(TId id)
        {
            throw new NotImplementedException();
        }

        public T GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public T Put(T newEntity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}