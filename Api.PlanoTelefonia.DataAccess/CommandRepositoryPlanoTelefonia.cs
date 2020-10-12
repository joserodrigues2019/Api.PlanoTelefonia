using System;
using System.Data.Entity;
using System.Linq;

namespace Api.PlanoTelefonia.DataAccess
{
    public class CommandRepositoryPlanoTelefonia<T> :ICommandRepositorySimnac<T> where T : BaseEntity
    {
        private readonly IDatabaseContextPlanoTelefonia _dbContextPlanoTelefonia;

        internal CommandRepositoryPlanoTelefonia(IDatabaseContextPlanoTelefonia dbContextPlanoTelefonia)
        {
            _dbContextPlanoTelefonia = dbContextPlanoTelefonia;
        }

        private void Adicionar(T entity)
        {
            _dbContextPlanoTelefonia.Set<T>().Add(entity);
        }

        private void Atualizar(T entity)
        {
            var e = _dbContextPlanoTelefonia.Entry(entity);
            _dbContextPlanoTelefonia.Entry(entity).State = EntityState.Modified;
        }

        public void Apagar(int id)
        {
            var entityTrackeable = _dbContextPlanoTelefonia.Set<T>().Find(id);
            if (entityTrackeable == null) { return; }
            _dbContextPlanoTelefonia.Set<T>().Remove(entityTrackeable);
        }

        public async void ApagarAssinc(int id)
        {
            var entityTrackeable = await _dbContextPlanoTelefonia.Set<T>().FindAsync(id);
            _dbContextPlanoTelefonia.Set<T>().Remove(entityTrackeable);
        }

        public void Apagar(long id)
        {
            var entityTrackeable = _dbContextPlanoTelefonia.Set<T>().Find(id);
            if (entityTrackeable == null) { return; }
            _dbContextPlanoTelefonia.Set<T>().Remove(entityTrackeable);
        }

        public async void ApagarAssinc(long id)
        {
            var entityTrackeable = await _dbContextPlanoTelefonia.Set<T>().FindAsync(id);
            _dbContextPlanoTelefonia.Set<T>().Remove(entityTrackeable);
        }


        public void Salvar(T entity)
        {
            var props = typeof(T)
                .GetProperties()
                .Where(prop =>
                    Attribute.IsDefined(prop,
                        typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));

            var codeValue = (props.First().GetValue(entity).GetType().Name == "Int64" ? (long)props.First().GetValue(entity) : (int)props.First().GetValue(entity));

            if (codeValue == 0)
            {
                this.Adicionar(entity);
            }
            else
            {
                this.Atualizar(entity);
            }
        }

    }
}
