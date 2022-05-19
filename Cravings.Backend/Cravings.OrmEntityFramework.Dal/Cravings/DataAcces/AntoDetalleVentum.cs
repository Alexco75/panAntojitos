using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Cravings.DataAccess
{
    [Table("ANTO_DETALLE_VENTA")]
    public partial class AntoDetalleVentum
    {
        [Key]
        [Column("CONS_VENTA")]
        public int ConsVenta { get; set; }
        [Key]
        [Column("CONS_PRODUCTO")]
        public int ConsProducto { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("VALOR_UNITARIO")]
        public int ValorUnitario { get; set; }
        [Column("IVA")]
        public int Iva { get; set; }
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("FECHA_REGISTRO", TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(ConsProducto))]
        [InverseProperty(nameof(AntoProducto.AntoDetalleVenta))]
        public virtual AntoProducto ConsProductoNavigation { get; set; }
        [ForeignKey(nameof(ConsVenta))]
        [InverseProperty(nameof(AntoVentum.AntoDetalleVenta))]
        public virtual AntoVentum ConsVentaNavigation { get; set; }
    }
}
