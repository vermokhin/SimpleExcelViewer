using Excel;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace SimpleExcelViewer.Infrastructure.Services.Excel
{
	/// <summary>
	/// Implementaion of <see cref="IExcelReaderService"/>
	/// </summary>
	public class ExcelReaderService : IExcelReaderService
	{
		public ExcelReaderService()
		{
		}

		public Task<DataSet> GetDataSetFromFile(string path)
		{
			try
			{
				using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
				{
					var reader = GetReader(stream, Path.GetExtension(path));

					return Task.FromResult(GetDataSetFromReader(reader));
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private IExcelDataReader GetReader(Stream stream, string fileExtension)
		{
			if (fileExtension == ".xls")
			{
				return ExcelReaderFactory.CreateBinaryReader(stream);
			}

			if (fileExtension == ".xlsx")
			{
				return ExcelReaderFactory.CreateOpenXmlReader(stream);
			}

			return null;
		}

		private DataSet GetDataSetFromReader(IExcelDataReader reader)
		{
			if (reader != null)
			{
				var result = reader.AsDataSet();

				//wrong file
				if (result.Tables.Count != 2)
				{
					throw new Exception();
				}

				return result;
			}

			return null;
		}
	}
}