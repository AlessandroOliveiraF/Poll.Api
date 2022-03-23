namespace Poll.Api.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
