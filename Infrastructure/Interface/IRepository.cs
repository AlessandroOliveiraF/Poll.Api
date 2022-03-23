namespace Poll.Api.Infrastructure.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
