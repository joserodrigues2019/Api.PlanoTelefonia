using Api.PlanoTelefonia.DataAccess.Entities;

namespace Api.PlanoTelefonia.DataAccess
{
    public class QueryStackPlanoTelefonia : IQueryStackPlanoTelefonia
    {
        private readonly IDatabaseContextPlanoTelefonia _contextPlanoTelefonia;

        public IQueryRepositoryPlanoTelefonia<PlanoTelefoniaEntity> PlanoTelefonia { get; }

        public QueryStackPlanoTelefonia(IDatabaseContextPlanoTelefonia contextPlanoTelefonia)
        {
            _contextPlanoTelefonia = contextPlanoTelefonia;

            PlanoTelefonia = new QueryRepositoryPlanoTelefonia<PlanoTelefoniaEntity>(_contextPlanoTelefonia);
        }
    }
}
