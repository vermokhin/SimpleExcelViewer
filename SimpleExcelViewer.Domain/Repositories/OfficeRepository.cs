using SimpleExcelViewer.Domain.Models;

namespace SimpleExcelViewer.Domain.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IRepository{T, TId}"/> for <see cref="Office"/>
    /// </summary>
    public class OfficeRepository : BaseRepository<Office, long>, IRepository<Office, long>
    {
        public OfficeRepository() : base()
        {
        }
    }
}