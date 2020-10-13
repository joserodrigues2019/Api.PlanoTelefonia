using Api.PlanoTelefonia.DataAccess.Entities;

namespace Api.PlanoTelefonia.DataAccess
{
    public interface IQueryStackPlanoTelefonia
    {
        IQueryRepositoryPlanoTelefonia<PlanoTelefoniaEntity> PlanoTelefonia { get; }
    }
}
