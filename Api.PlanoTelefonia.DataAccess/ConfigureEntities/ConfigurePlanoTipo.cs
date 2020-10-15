namespace Api.PlanoTelefonia.DataAccess
{
    using Api.PlanoTelefonia.DataAccess.Entities;
    using System.Data.Entity;

    public partial class DatabaseContextPlanoTelefonia : DbContext
    {
        private static void ConfigurePlanoTipo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanoTipoEntity>()
                .Property(e => e.IdPlanoTipo);
        }

    }
}
