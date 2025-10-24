namespace Application.DataLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        
        Task<T> FindAsync(params object[] keyValues);
        
        Task<T> InsertAsync(T entity, bool saveChanges = true);
        
        Task<T> DeleteAsync(int id, bool saveChanges = true);
    }
}



