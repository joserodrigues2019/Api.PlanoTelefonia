using Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel;
using Api.PlanoTelefonia.DataAccess;
using System.Collections.Generic;

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

            return null;
        }
    }
}
