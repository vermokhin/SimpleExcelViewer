using SimpleExcelViewer.Domain.Data;
using System.Data.Entity;

namespace SimpleExcelViewer.Infrastructure.Data.EntityFramework
{
	/// <summary>
	/// Base implementation of <see cref="IBaseEntityDataContext"/>
	/// </summary>
	public abstract class BaseEntityDataContext : DbContext, IBaseEntityDataContext
	{
		public BaseEntityDataContext(string connectionString) : base(connectionString)
		{
		}

		public void SetEntityState<T>(T entity, EntityStates state) where T : class
		{
			Entry(entity).State = (EntityState)state;
		}
	}
}