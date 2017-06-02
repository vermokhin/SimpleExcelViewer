using System.Data;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Services.Excel
{
	/// <summary>
	/// Service for working with excel file
	/// </summary>
	public interface IExcelReaderService
	{
		/// <summary>
		/// Rrturns DataSet object with all excel spreadsheets
		/// </summary>
		/// <param name="path">Excel document path</param>
		/// <returns></returns>
		Task<DataSet> GetDataSetFromFile(string path);
	}
}