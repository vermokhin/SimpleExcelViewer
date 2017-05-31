using SimpleExcelViewer.Domain.Models;

namespace SimpleExcelViewer.Domain.Repositories
{
    /// <summary>
    /// Implementation of <see cref="IRepository{T, TId}"/> for <see cref="Manager"/>
    /// </summary>
    public class ManagerRepository : BaseRepository<Manager, long>, IRepository<Manager, long>
    {
        public ManagerRepository() : base()
        {
        }
    }
}