using SimpleExcelViewer.Domain.Models;
using System.Linq;

namespace SimpleExcelViewer.Domain.Repositories
{
	public interface IOfficeRepository : IRepository<Office, long>
	{
		/// <summary>
		/// Returns all offices where <see cref="Manager"/> specified by <paramref name="managerId"/> works
		/// </summary>
		/// <param name="managerId"><see cref="Manager.Id"/></param>
		/// <returns>Query with collection of <see cref="Office"/></returns>
		IQueryable<Office> GetAllOfficesForManager(long managerId);
	}
}