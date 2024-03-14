using MoviesInfoAPI.Models;

namespace MoviesInfoAPI.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FindById(byte id);
        Task<TEntity> FindById(int id);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);

    }
}
