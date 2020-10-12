namespace Api.PlanoTelefonia.DataAccess
{
    public interface ICommandRepositoryPlanoTelefonia<T> where T : BaseEntity
    {
        void Apagar(int id);

        void ApagarAssinc(int id);

        void Apagar(long id);

        void ApagarAssinc(long id);

        void Salvar(T entity);

    }
}
