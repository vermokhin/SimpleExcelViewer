using SimpleExcelViewer.Domain.Data;
using SimpleExcelViewer.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Data.EntityFramework
{
	public class EntityDataContext : BaseEntityDataContext, IEntityDataContext
	{
		private IDataSet<Office> _offices;
		private IDataSet<Manager> _managers;

		public EntityDataContext(string connectionString): base(connectionString)
		{
			Database.SetInitializer<EntityDataContext>(null);
		}

		public IDataSet<Office> Offices
		{
			get => _offices ?? (_offices = new EntityDataSet<Office>(Set<Office>(), this));
		}

		public IDataSet<Manager> Managers
		{
			get => _managers ?? (_managers = new EntityDataSet<Manager>(Set<Manager>(), this));
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Manager>().ToTable("Managers");
			modelBuilder.Entity<Manager>().HasKey(m => m.Id);
			modelBuilder.Entity<Manager>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			modelBuilder.Entity<Office>().ToTable("Offices");
			modelBuilder.Entity<Office>().HasKey(o => o.Id);
			modelBuilder.Entity<Office>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
		}
	}
}