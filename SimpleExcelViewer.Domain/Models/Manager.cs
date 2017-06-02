namespace SimpleExcelViewer.Domain.Models
{
	/// <summary>
	/// Manager domain model
	/// </summary>
	public class Manager : IModel<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		/// <summary>
		/// <see cref="Office.Id"/>
		/// </summary>
		public long OfficeId { get; set; }
	}
}