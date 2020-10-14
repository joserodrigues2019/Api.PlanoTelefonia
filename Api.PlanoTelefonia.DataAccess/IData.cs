using System;

namespace Api.PlanoTelefonia.DataAccess
{
    public interface IData
    {
        DateTime DataAlteracao { get; set; }
        DateTime DataInclusao { get; set; }
    }
}
