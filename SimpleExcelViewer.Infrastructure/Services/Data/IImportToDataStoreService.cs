using System.Data;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Services.Data
{
	public interface IImportToDataStoreService
	{
		Task ImportFromDataSet(DataSet dataSet);
	}
}