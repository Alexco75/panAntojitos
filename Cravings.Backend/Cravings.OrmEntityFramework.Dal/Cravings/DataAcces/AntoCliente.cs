using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Cravings.DataAccess
{
    [Table("ANTO_CLIENTE")]
    public partial class AntoCliente
    {
        public AntoCliente()
        {
            AntoVenta = new HashSet<AntoVentum>();
        }

        [Key]
        [Column("CONS_CLIENTE")]
        public int ConsCliente { get; set; }
        [Column("TIPO_IDENTIFICACION")]
        public int TipoIdentificacion { get; set; }
        [Column("NUMERO_IDENTIFICACION")]
        public int NumeroIdentificacion { get; set; }
        [Required]
        [Column("PRIMER_NOMBRE")]
        [StringLength(50)]
        public string PrimerNombre { get; set; }
        [Column("SEGUNDO_NOMBRE")]
        [StringLength(50)]
        public string SegundoNombre { get; set; }
        [Required]
        [Column("PRIMER_APELLIDO")]
        [StringLength(50)]
        public string PrimerApellido { get; set; }
        [Column("SEGUNDO_APELLIDO")]
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("DIRECCION_RESIDENCIAL")]
        [StringLength(100)]
        public string DireccionResidencial { get; set; }
        [Column("DIRECCION_TRABAJO")]
        [StringLength(100)]
        public string DireccionTrabajo { get; set; }
        [Column("TELEFONO_CELULAR")]
        [StringLength(50)]
        public string TelefonoCelular { get; set; }
        [Column("TELEFONO_FIJO")]
        [StringLength(50)]
        public string TelefonoFijo { get; set; }
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("FECHA_REGISTRO", TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(AntoVentum.ConsClienteNavigation))]
        public virtual ICollection<AntoVentum> AntoVenta { get; set; }
    }
}
