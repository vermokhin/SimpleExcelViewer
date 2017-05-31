namespace SimpleExcelViewer.Domain.Models
{
    /// <summary>
    /// Commom domain model interface
    /// </summary>
    /// <typeparam name="TId">Domain entity type. This type param is covariant. 
    /// That is, you can use either the type you specified or any type that is more derived.</typeparam>
    public interface IModel<T>
    {
        /// <summary>
        /// Model identity
        /// </summary>
        T Id { get; }
    }
}