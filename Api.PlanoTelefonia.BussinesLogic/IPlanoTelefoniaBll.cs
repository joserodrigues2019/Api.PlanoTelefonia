using Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel;
using System.Collections.Generic;

namespace Api.PlanoTelefonia.BussinesLogic
{
    public interface IPlanoTelefoniaBll
    {
        List<PlanoTelefoniaVM> ListarPlanosCodigo(string codigo);
        List<PlanoTelefoniaVM> ListarPlanosTodos(IEnumerable<ParametrosConsultaPlanoVM> parametros);

        string SalvarPlanos(List<PlanoTelefoniaVM> listaPlano);
        string AlterarPlanos(List<PlanoTelefoniaVM> listaPlano);
        string ExcluirPlano(int idPlano);
    }
}
