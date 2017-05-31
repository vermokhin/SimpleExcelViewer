using System;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Domain.Data
{
	/// <summary>
	/// Defines generic data context interface.
	/// </summary>
	public interface IBaseEntityDataContext : IDisposable
	{
		/// <summary>
		/// Saves all changes made in this context to underlying storage.
		/// </summary>
		/// <returns>Number of objects written to the underlying storage.</returns>
		int SaveChanges();

		/// <summary>
		/// Asynchronously saves all changes made in this context to the underlying storage.
		/// </summary>
		/// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying storage.</returns>
		Task<int> SaveChangesAsync();

		/// <summary>
		/// Sets state for entity object
		/// </summary>
		void SetEntityState<T>(T entity, EntityStates state) where T : class;
	}

	/// <summary>
	/// Entity states for IDataContext
	/// </summary>
	public enum EntityStates
	{
		/// <summary>
		/// The entity is not being tracked by the context. An entity is in this state immediately
		///	 after it has been created with the new operator or with one of the System.Data.Entity.DbSet
		///	 Create methods.
		/// </summary>
		Detached = 1,

		/// <summary>
		///	 The entity is being tracked by the context and exists in the database, and its
		///	 property values have not changed from the values in the database.
		/// </summary>
		Unchanged = 2,

		/// <summary>
		///	 The entity is being tracked by the context but does not yet exist in the database.
		/// </summary>
		Added = 4,

		/// <summary>
		///	 The entity is being tracked by the context and exists in the database, but has
		///	 been marked for deletion from the database the next time SaveChanges is called.
		/// </summary>
		Deleted = 8,

		/// <summary>
		/// The entity is being tracked by the context and exists in the database, and some
		///	 or all of its property values have been modified.
		/// </summary>
		Modified = 16
	}
}