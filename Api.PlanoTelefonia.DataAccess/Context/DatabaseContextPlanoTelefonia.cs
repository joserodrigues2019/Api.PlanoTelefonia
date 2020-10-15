using Api.PlanoTelefonia.DataAccess.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Api.PlanoTelefonia.DataAccess
{
	public partial class DatabaseContextPlanoTelefonia : DbContext, IDatabaseContextPlanoTelefonia
	{
		public virtual DbSet<PlanoTelefoniaEntity> PlanoTelefonia { get; set; }
		public virtual DbSet<PlanoTipoEntity> PlanoTipo { get; set; }

		private string nomeSchema = "dbo";

        public DatabaseContextPlanoTelefonia() : base("name=DatabaseContextPlanoTelefonia")
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContextPlanoTelefonia>(null);

            //Console.Write(Database.Log);
        }

        public DatabaseContextPlanoTelefonia(DbConnection dbConnection) : base(dbConnection, true)
        {
            Database.SetInitializer<DatabaseContextPlanoTelefonia>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(nomeSchema);

			ConfigurePlanoTelefonia(modelBuilder);
			ConfigurePlanoTipo(modelBuilder);
		}

		public override int SaveChanges()
		{
			var objectStateEntries = ChangeTracker.Entries()
			.Where(e => e.Entity is IData && (e.State == EntityState.Modified || e.State == EntityState.Added)).ToList();
			var currentTime = DateTime.Now;

			foreach (var entry in objectStateEntries)
			{
				var entityBase = entry.Entity as IData;
				if (entityBase == null) continue;
				if (entry.State == EntityState.Added)
				{
					entityBase.DataInclusao = currentTime;
				}
				else
				{
					entry.Property(nameof(IData.DataInclusao)).IsModified = false;
				}

				entityBase.DataAlteracao = currentTime;
			}

			return base.SaveChanges();
		}

	}
}
