namespace Api.PlanoTelefonia.DataAccess
{
    using Api.PlanoTelefonia.DataAccess.Entities;
    using System.Data.Entity;

    public partial class DatabaseContextPlanoTelefonia : DbContext
    {
        private static void ConfigurePlanoTelefonia(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanoTelefoniaEntity>()
                .Property(e => e.IdPlano);
        }
    }
}
