using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.PlanoTelefonia.DataAccess.Entities
{
    [Table("PLANO_TELEFONIA")]
    public class PlanoTelefoniaEntity: BaseEntity
    {
        public virtual PlanoTipoEntity PlanoTipo { get; set; }

        [Key]
        [Column("PLANO_ID")]
        public int IdPlano { get; set; }

        [Required]
        [StringLength(10)]
        [Column("PLANO_CODIGO")]
        public string Codigo { get; set; }

        [Required]
        [Column("PLANO_MINUTOS")]
        public int Minutos { get; set; }

        [StringLength(50)]
        [Column("PLANO_FRANQUIA_INTERNET")]
        public string FranquiaInternet { get; set; }

        [Column("PLANO_VALOR")]
        public decimal Valor { get; set; }

        [Required]
        [Column("PLANO_ID_TIPO")]
        [ForeignKey(nameof(PlanoTipo))]
        public int IdPlanoTipo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("PLANO_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
    }
}
