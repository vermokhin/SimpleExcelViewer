using SimpleExcelViewer.Domain.Data;
using SimpleExcelViewer.Domain.Models;

namespace SimpleExcelViewer.Infrastructure.Data
{
	/// <summary>
	/// Represent core application data context
	/// </summary>
	public interface IEntityDataContext : IBaseEntityDataContext
	{
		/// <summary>
		/// Set of <see cref="Office"/>
		/// </summary>
		IDataSet<Office> Offices { get; }

		/// <summary>
		/// Set of <see cref="Manager"/>
		/// </summary>
		IDataSet<Manager> Managers { get; }
	}
}