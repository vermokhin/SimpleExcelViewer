﻿using SimpleExcelViewer.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Domain.Repositories
{
    /// <summary>
    /// Common repository interface
    /// </summary>
    public interface IRepository<T, TId> where T : class, IModel<TId>
    {
		/// <summary>
		/// Returns all existing entities from data store
		/// </summary>
		/// <returns></returns>
		IQueryable<T> GetAll();

        /// <summary>
        /// Returns existing entity from data store by <paramref name="id"/>
        /// </summary>
        /// <param name="id"><see cref="T.Id"/></param>
        /// <returns><see cref="T"/> entity</returns>
        T GetById(TId id);

        /// <summary>
        /// Removes existing entity from data store by <see cref="T.Id"/>
        /// </summary>
        /// <param name="id"><see cref="T.Id"/></param>
        /// <returns>Removed entity</returns>
        T DeletedById(TId id);

        /// <summary>
        /// Saves new <see cref="T"/> entity in data store
        /// </summary>
        /// <param name="newEntity">new <see cref="T"/> entity</param>
        /// <returns>Saved <see cref="T"/> entity</returns>
        T Put(T newEntity);
        
        /// <summary>
        /// Updates existing <see cref="T"/> entity in data store
        /// </summary>
        /// <param name="entity"><see cref="T"/> entity to update</param>
        /// <returns>Updates <see cref="T"/> entity</returns>
        T Update(T entity);

		/// <summary>
		/// Inserts collection of <see cref="T"/> entities to data store
		/// </summary>
		/// <param name="entities">Collection of <see cref="T"/> entities</param>
		/// <returns></returns>
		Task BulkAddAsync(ICollection<T> entities);
    }
}