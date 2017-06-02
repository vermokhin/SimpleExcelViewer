namespace SimpleExcelViewer.Domain.Models
{
	/// <summary>
	/// Manager domain model
	/// </summary>
	public class Manager : IModel<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		/// <summary>
		/// <see cref="Office.Id"/>
		/// </summary>
		public int Office_Id { get; set; }
	}
}