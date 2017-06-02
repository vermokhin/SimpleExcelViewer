using SimpleExcelViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Domain.Repositories
{
	public interface IManagerRepository: IRepository<Manager, int>
	{
		/// <summary>
		/// Returns all managers from one <see cref="Office"/> by specified <see cref="Office.Id"/>
		/// </summary>
		/// <param name="officeId"><see cref="Office.Id"/></param>
		/// <returns>Query with collection of <see cref="Manager"/></returns>
		IQueryable<Manager> GetManagersFromOffice(int officeId);
	}
}
