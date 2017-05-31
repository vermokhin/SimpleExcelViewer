using SimpleExcelViewer.Domain.Data;
using SimpleExcelViewer.Domain.Models;
using System.Linq;

namespace SimpleExcelViewer.Domain.Repositories
{
	/// <summary>
	/// Implementation of <see cref="IRepository{T, TId}"/> for <see cref="Manager"/>
	/// </summary>
	public class ManagerRepository : BaseRepository<Manager, long>, IManagerRepository
	{
		public ManagerRepository(IDataSet<Manager> dataSet) : base(dataSet)
		{
		}

		public IQueryable<Manager> GetManagersFromOffice(long officeId)
		{
			return DataSet.Where(m => m.OfficeId == officeId);
		}
	}
}