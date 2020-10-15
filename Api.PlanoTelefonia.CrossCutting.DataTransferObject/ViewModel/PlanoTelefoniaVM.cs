using System;

namespace Api.PlanoTelefonia.CrossCutting.DataTransferObject.ViewModel
{
    public class PlanoTelefoniaVM
    {
        public int IdPlano { get; set; }
        public string Codigo { get; set; }
        public int Minutos { get; set; }
        public string FranquiaInternet { get; set; }
        public decimal Valor { get; set; }
        public int IdPlanoTipo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int DDD { get; set; }
        public string Operadora { get; set; }

        public PlanoTipoVM  PlanoTipo { get; set; }

    }
}
