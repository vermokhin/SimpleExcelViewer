using SimpleExcelViewer.Domain.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Data.EntityFramework
{
	/// <summary>
	/// Implements <see cref="IDataSet{T}"/> with Entity Framework.
	/// </summary>
	/// <typeparam name="TEntity">Entity type.</typeparam>
	public class EntityDataSet<TEntity> : IDataSet<TEntity> where TEntity : class
	{
		private readonly DbSet<TEntity> _dbSet;
		private readonly IBaseEntityDataContext _context;

		/// <summary>
		/// Initializes new instance of <see cref="EntityDataSet{TEntity}"/> with given <see cref="System.Data.Entity.DbSet{TEntity}"/>.
		/// </summary>
		/// <param name="dbSet"></param>
		/// <param name="context"></param>
		public EntityDataSet(DbSet<TEntity> dbSet, IBaseEntityDataContext context)
		{
			_dbSet = dbSet;
			_context = context;
		}

		/// <summary>
		/// Gets underlying Entity Framework db set.
		/// </summary>
		public DbSet<TEntity> DbSet { get { return _dbSet; } }

		/// <inheritdoc/>
		public IEnumerator<TEntity> GetEnumerator()
		{
			return ((IEnumerable<TEntity>)_dbSet).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <inheritdoc/>
		public Expression Expression
		{
			get { return ((IQueryable<TEntity>)_dbSet).Expression; }
		}

		/// <inheritdoc/>
		public Type ElementType
		{
			get { return ((IQueryable<TEntity>)_dbSet).ElementType; }
		}

		/// <inheritdoc/>
		public IQueryProvider Provider
		{
			get { return ((IQueryable<TEntity>)_dbSet).Provider; }
		}

		/// <inheritdoc/>
		public TEntity Add(TEntity entity)
		{
			return _dbSet.Add(entity);
		}

		/// <inheritdoc/>
		public TEntity Remove(TEntity entity)
		{
			return _dbSet.Remove(entity);
		}

		/// <inheritdoc/>
		public TEntity Find(params object[] keyValues)
		{
			return _dbSet.Find(keyValues);
		}

		/// <inheritdoc/>
		public Task<TEntity> FindAsync(params object[] keyValues)
		{
			return _dbSet.FindAsync(keyValues);
		}

		/// <summary>
		/// Finds first entity satisfying the passed predicate.
		/// </summary>
		/// <param name="predicate">Predicate to test entity against.</param>
		/// <returns><typeparamref name="TEntity"/> that sitisfies the <paramref name="predicate"/>.</returns>
		public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.FirstOrDefaultAsync(predicate);
		}

		/// <summary>
		/// Returns related IDataContext
		/// </summary>
		/// <returns></returns>
		public IBaseEntityDataContext GetDataContext()
		{
			return _context;
		}

		public Task<TEntity> AddAsync(TEntity entity)
		{
			return Task.FromResult(Add(entity));
		}

		public IQueryable<TEntity> Clear()
		{
			_dbSet.RemoveRange(_dbSet);
			GetDataContext().SaveChanges();

			return _dbSet;
		}
	}
}