using Order.Microservice.Domain.Interfaces.Infra;
using Order.Microservice.Infra.Contexts;

namespace Order.Microservice.Infra.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _session;

        public UnitOfWork(AppDbContext session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session?.Transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session?.Transaction?.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
        }
}