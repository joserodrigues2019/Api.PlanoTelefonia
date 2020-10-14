using Api.PlanoTelefonia.DataAccess.Entities;

namespace Api.PlanoTelefonia.DataAccess
{
    public interface ICommandStackPlanoTelefonia
    {
        ICommandRepositoryPlanoTelefonia<PlanoTelefoniaEntity> PlanoTelefonia { get; set; }
        void Save();
    }
}
