namespace SimpleExcelViewer.Domain.Models
{
	/// <summary>
	/// Office domain model
	/// </summary>
	public class Office : IModel<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }
	}
}