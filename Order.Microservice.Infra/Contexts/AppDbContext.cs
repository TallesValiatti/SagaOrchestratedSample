
using System.Data;
using System.Data.SqlClient;

namespace Order.Microservice.Infra.Contexts
{
   public sealed class AppDbContext : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }

        public AppDbContext(string connectionString)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}