using Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel;
using Api.PlanoTelefonia.DataAccess;
using Api.PlanoTelefonia.DataAccess.Entities;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Api.PlanoTelefonia.BussinesLogic
{
    public class PlanoTelefoniaBll : IPlanoTelefoniaBll
    {
        private readonly ICommandStackPlanoTelefonia _command;
        private readonly IQueryStackPlanoTelefonia _query;

        public PlanoTelefoniaBll(ICommandStackPlanoTelefonia command, 
                                   IQueryStackPlanoTelefonia query)
        {
            _command = command;
            _query = query;
        }

        public List<PlanoTelefoniaVM> ListarPlanos(string codigo)
        {
            var result = _query.PlanoTelefonia.Listar<PlanoTelefoniaVM>( l => l.Codigo == codigo);

            return result;
        }

        public string AlterarPlanos(List<PlanoTelefoniaVM> listaPlano)
        {
            foreach (var item in listaPlano)
            {
                var _planoEntity = new PlanoTelefoniaEntity()
                {
                    IdPlano = item.IdPlano,
                    Codigo = item.Codigo,
                    Minutos = item.Minutos,
                    FranquiaInternet = item.FranquiaInternet,
                    Valor = item.Valor,
                    IdPlanoTipo = item.IdPlanoTipo,
                    DDD = item.DDD,
                    Operadora = item.Operadora
                };
                _command.PlanoTelefonia.Salvar(_planoEntity);
            }

            _command.Save();

            return "Registro Alteado";

        }

        public string ExcluirPlano(int idPlano)
        {
            _command.PlanoTelefonia.Apagar(idPlano);
            _command.Save();
            return "Registro Excluído";
        }

        public string SalvarPlanos(List<PlanoTelefoniaVM> listaPlano)
        {
            try
            {
                foreach (var item in listaPlano)
                {
                    var _planoEntity = new PlanoTelefoniaEntity()
                    {
                        Codigo = item.Codigo,
                        Minutos = item.Minutos,
                        FranquiaInternet = item.FranquiaInternet,
                        Valor = item.Valor,
                        IdPlanoTipo = item.IdPlanoTipo,
                        DDD = item.DDD,
                        Operadora = item.Operadora
                    };
                        _command.PlanoTelefonia.Salvar(_planoEntity);
                }

                _command.Save();

                return "Registro Salvo";

            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message.ToString());
            }
        }
    }
}
