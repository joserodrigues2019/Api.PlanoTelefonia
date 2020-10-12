using Api.PlanoTelefonia.DataAccess.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace Api.PlanoTelefonia.DataAccess
{
	public partial class DatabaseContextPlanoTelefonia : DbContext, IDatabaseContextPlanoTelefonia
	{
		public virtual DbSet<PlanoTelefoniaEntity> PlanoTelefonia { get; set; }

		private string nomeSchema = "dbo";

        public DatabaseContextPlanoTelefonia() : base("name=DatabaseContextPlanoTelefonia")
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContextPlanoTelefonia>(null);
        }

        public DatabaseContextPlanoTelefonia(DbConnection dbConnection) : base(dbConnection, true)
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContextPlanoTelefonia>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(nomeSchema);

			ConfigurePlanoTelefonia(modelBuilder);
		}
	}
}
