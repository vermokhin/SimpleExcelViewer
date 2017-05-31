using SimpleExcelViewer.Domain.Data;
using SimpleExcelViewer.Domain.Models;
using System;
using System.Linq;

namespace SimpleExcelViewer.Domain.Repositories
{
	/// <summary>
	/// Implementation of <see cref="IRepository{T, TId}"/> for <see cref="Office"/>
	/// </summary>
	public class OfficeRepository : BaseRepository<Office, long>, IOfficeRepository
	{
		public OfficeRepository(IDataSet<Office> dataSet) : base(dataSet)
		{
		}

		public IQueryable<Office> GetAllOfficesForManager(long managerId)
		{
			throw new NotImplementedException();
		}
	}
}