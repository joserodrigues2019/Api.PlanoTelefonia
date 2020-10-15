using Api.PlanoTelefonia.BussinesLogic;
using Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.PlanoTelefonia.ApplicationService.Services
{
    public class PlanoTelefoniaController : ApiController
    {
        private readonly IPlanoTelefoniaBll _planotelefonia;

        public PlanoTelefoniaController(IPlanoTelefoniaBll planotelefonia)
        {
            _planotelefonia = planotelefonia;
        }

        /// <summary>Consultar pelo codigo</summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public List<PlanoTelefoniaVM> Get([FromUri] string codigo)
        {
            return _planotelefonia.ListarPlanosCodigo(codigo);
        }

        /// <summary>Consultar pelo codigo</summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<PlanoTelefoniaVM> Get([FromBody] IEnumerable<ParametrosConsultaPlanoVM> parametros)
        {
            return _planotelefonia.ListarPlanosTodos(parametros);
        }

        /// <summary>Salva Novo Plano Telefonia</summary>
        /// <param name="planoTelefoniaVM"></param>
        /// <returns></returns>
        public string Post([FromBody] IEnumerable<PlanoTelefoniaVM> planoTelefoniaVM)
        {
            return _planotelefonia.SalvarPlanos(planoTelefoniaVM.ToList());
        }

        /// <summary>Salva o BatimentoSefaz</summary>
        /// <param name="planoTelefoniaVM"></param>
        /// <returns></returns>
        public string Put([FromBody] IEnumerable<PlanoTelefoniaVM> planoTelefoniaVM)
        {
            return _planotelefonia.AlterarPlanos(planoTelefoniaVM.ToList());
        }

        /// <summary>Deletar arquivos anexos de transporte pelo ID</summary>
        /// <param name="idPlano">ID Arquivo Anexo</param>
        public string Delete(int idPlano)
        {
            return _planotelefonia.ExcluirPlano(idPlano);
        }
    }
}
