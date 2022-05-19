using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Cravings.DataAccess
{
    [Table("ANTO_VENTA")]
    public partial class AntoVentum
    {
        public AntoVentum()
        {
            AntoDetalleVenta = new HashSet<AntoDetalleVentum>();
        }

        [Key]
        [Column("CONS_VENTA")]
        public int ConsVenta { get; set; }
        [Column("CONS_CLIENTE")]
        public int ConsCliente { get; set; }
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("FECHA_REGISTRO", TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(ConsCliente))]
        [InverseProperty(nameof(AntoCliente.AntoVenta))]
        public virtual AntoCliente ConsClienteNavigation { get; set; }
        [InverseProperty(nameof(AntoDetalleVentum.ConsVentaNavigation))]
        public virtual ICollection<AntoDetalleVentum> AntoDetalleVenta { get; set; }
    }
}
