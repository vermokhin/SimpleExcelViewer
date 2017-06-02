namespace SimpleExcelViewer.Domain.Models
{
	/// <summary>
	/// Office domain model
	/// </summary>
	public class Office : IModel<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}