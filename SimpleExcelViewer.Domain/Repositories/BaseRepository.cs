using SimpleExcelViewer.Domain.Data;
using SimpleExcelViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Domain.Repositories
{
    /// <summary>
    /// Abstract implementation of <see cref="IRepository{T, TId}"/>
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TId"><see cref="T.Id"/></typeparam>
    public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : class, IModel<TId>
    {
		private readonly IDataSet<T> _dataSet;

		protected IDataSet<T> DataSet { get => _dataSet; }

        public BaseRepository(IDataSet<T> dataSet)
        {
			_dataSet = dataSet;
        }

        public T DeletedById(TId id)
        {
			var entity = GetById(id);
			_dataSet.Remove(entity);
			_dataSet.GetDataContext().SaveChanges();
			return entity;
        }

        public T GetById(TId id)
        {
			var entity = _dataSet.Find(id);
			if (entity == null)
			{
				throw new Exception($"Entity with id = {id} was not found");
			}

			return entity;
        }

        public T Put(T newEntity)
        {
			_dataSet.Add(newEntity);
			_dataSet.GetDataContext().SaveChanges();
			return newEntity;
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

		public async Task BulkAddAsync(ICollection<T> entities)
		{
			foreach(var entity in entities)
			{
				await _dataSet.AddAsync(entity);
			}

			await _dataSet.GetDataContext().SaveChangesAsync();
		}
	}
}