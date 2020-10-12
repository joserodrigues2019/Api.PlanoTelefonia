using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.PlanoTelefonia.DataAccess.Entities
{
    [Table("PLANO_TIPO")]
    public class PlanoTipoEntity
    {
        [Key]
        [Column("PLANO_ID_TIPO")]
        public int IdPlanoTipo { get; set; }

        [Required]
        [Column("PLANO_DESCRICAO_TIPO")]
        [StringLength(50)]
        public string DescricaoTipo { get; set; }
    }
}
