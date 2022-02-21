namespace Order.Microservice.Domain.Interfaces.Infra
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Dispose();
    }
}