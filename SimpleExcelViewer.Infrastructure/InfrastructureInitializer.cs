using DryIoc;
using SimpleExcelViewer.Domain.Repositories;
using SimpleExcelViewer.Infrastructure.Data;
using SimpleExcelViewer.Infrastructure.Data.EntityFramework;
using SimpleExcelViewer.Infrastructure.Services.Data;
using SimpleExcelViewer.Infrastructure.Services.Excel;

namespace SimpleExcelViewer.Infrastructure
{
	public static class InfrastructureInitializer
	{
		public static void Initialize(IContainer container)
		{
			#region Context

			container.Register<IEntityDataContext>(made: Made.Of(() => new EntityDataContext("DataContext")), reuse: Reuse.InResolutionScope);
			container.Register(Made.Of(r => ServiceInfo.Of<IEntityDataContext>(), f => f.Managers));
			container.Register(Made.Of(r => ServiceInfo.Of<IEntityDataContext>(), f => f.Offices));

			#endregion Context

			#region Repositories

			container.Register<IOfficeRepository, OfficeRepository>();
			container.Register<IManagerRepository, ManagerRepository>();

			#endregion Repositories

			#region Services

			container.Register<IExcelReaderService, ExcelReaderService>();
			container.Register<IImportToDataStoreService, ImportToDataStoreService>();

			#endregion Services
		}
	}
}