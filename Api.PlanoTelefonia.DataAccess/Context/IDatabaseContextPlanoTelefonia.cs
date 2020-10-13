using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Api.PlanoTelefonia.DataAccess
{
    public interface IDatabaseContextPlanoTelefonia
    {
        Database Database { get; }

        DbEntityEntry Entry(object entity);

        DbSet<T> Set<T>() where T : class;
    }
}
