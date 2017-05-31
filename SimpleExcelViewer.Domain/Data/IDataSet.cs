using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Domain.Data
{
	/// <summary>
	/// Represents generic data set with querying capabilities.
	/// </summary>
	/// <typeparam name="T">The type that defines the set.</typeparam>
	public interface IDataSet<T> : IQueryable<T>
		where T : class
	{
		/// <summary>
		/// Adds entity to the set.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		/// <returns>The entity.</returns>
		T Add(T entity);

		/// <summary>
		/// Removes entity from the set.
		/// </summary>
		/// <param name="entity">The entity to remove.</param>
		/// <returns>The entity.</returns>
		T Remove(T entity);

		/// <summary>
		/// Finds entity in the set with specified key.
		/// </summary>
		/// <param name="keyValues">The values of key for the entity to be found.</param>
		/// <returns>The entity found, or null.</returns>
		T Find(params object[] keyValues);

		/// <summary>
		/// Finds entity in the set with specified key.
		/// </summary>
		/// <param name="keyValues">The values of key for the entity to be found.</param>
		/// <returns>Task which return entity found, or null when completed.</returns>
		Task<T> FindAsync(params object[] keyValues);

		/// <summary>
		/// Finds first entity satisfying the passed predicate.
		/// </summary>
		/// <param name="predicate">Predicate to test entity against.</param>
		/// <returns><typeparamref name="T"/> that sitisfies the <paramref name="predicate"/>.</returns>
		Task<T> FindAsync(Expression<Func<T, bool>> predicate);

		/// <summary>
		/// Returns related IDataContext object
		/// </summary>
		IBaseEntityDataContext GetDataContext();
	}
}