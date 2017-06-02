using System.Threading.Tasks;

namespace SimpleExcelViewer.Services.Excel
{
	/// <summary>
	/// Service for working with excel file
	/// </summary>
	public interface IExcelService
	{
		/// <summary>
		/// Load data from excel document to data store
		/// </summary>
		/// <param name="path">Path to excel document</param>
		/// <returns></returns>
		Task LoadToDataStore(string path);
	}
}