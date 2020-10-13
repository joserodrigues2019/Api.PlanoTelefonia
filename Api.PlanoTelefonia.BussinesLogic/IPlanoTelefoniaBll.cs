using Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel;
using System.Collections.Generic;

namespace Api.PlanoTelefonia.BussinesLogic
{
    public interface IPlanoTelefoniaBll
    {
        List<PlanoTelefoniaVM> ListarPlanos(string codigo);
    }
}
