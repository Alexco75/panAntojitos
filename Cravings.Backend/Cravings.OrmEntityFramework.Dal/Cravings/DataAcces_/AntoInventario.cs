using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Cravings.DataAccess
{
    [Table("ANTO_INVENTARIO")]
    public partial class AntoInventario
    {
        [Key]
        [Column("CONS_INVENTARIO")]
        public int ConsInventario { get; set; }
        [Column("CONS_PRODUCTO")]
        public int ConsProducto { get; set; }
        [Column("STOCK")]
        public int Stock { get; set; }
        [Required]
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("FECHA_REGISTRO", TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(ConsProducto))]
        [InverseProperty(nameof(AntoProducto.AntoInventarios))]
        public virtual AntoProducto ConsProductoNavigation { get; set; }
    }
}
