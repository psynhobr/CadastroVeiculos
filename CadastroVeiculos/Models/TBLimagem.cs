namespace CadastroVeiculos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("TBLimagem")]
    public partial class TBLimagem
    {
        public int Id { get; set; }

        [StringLength(8)]
        public string Placa { get; set; }

        [StringLength(11)]
        public string Renavan { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(11)]
        public string CPF { get; set; }

        [DisplayName("Fotos")]
        public string imagem { get; set; }

        [NotMapped]

        public HttpPostedFileBase ImagemFile { get; set; }
    }
}
