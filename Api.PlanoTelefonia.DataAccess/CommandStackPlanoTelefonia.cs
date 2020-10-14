using Api.PlanoTelefonia.DataAccess.Entities;

namespace Api.PlanoTelefonia.DataAccess
{
    public class CommandStackPlanoTelefonia : ICommandStackPlanoTelefonia
    {
        private readonly IDatabaseContextPlanoTelefonia _contextPlanoTelefonia;

        public ICommandRepositoryPlanoTelefonia<PlanoTelefoniaEntity> PlanoTelefonia { get; set; }

        public CommandStackPlanoTelefonia(IDatabaseContextPlanoTelefonia contextPlanoTelefonia)
        {
            _contextPlanoTelefonia = contextPlanoTelefonia;

            PlanoTelefonia = new CommandRepositoryPlanoTelefonia<PlanoTelefoniaEntity>(_contextPlanoTelefonia);
        }

        public void Save()
        {
            _contextPlanoTelefonia.SaveChanges();
        }

    }
}
