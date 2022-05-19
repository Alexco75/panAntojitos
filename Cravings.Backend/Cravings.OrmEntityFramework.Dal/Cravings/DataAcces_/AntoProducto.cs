using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Cravings.DataAccess
{
    [Table("ANTO_PRODUCTO")]
    public partial class AntoProducto
    {
        public AntoProducto()
        {
            AntoDetalleVenta = new HashSet<AntoDetalleVentum>();
            AntoInventarios = new HashSet<AntoInventario>();
        }

        [Key]
        [Column("CONS_PRODUCTO")]
        public int ConsProducto { get; set; }
        [Required]
        [Column("NOMBRE")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Column("DESCRIPCION")]
        [StringLength(300)]
        public string Descripcion { get; set; }
        [Column("VALOR_UNIDAD", TypeName = "money")]
        public decimal ValorUnidad { get; set; }
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("FECHA_REGISTRO", TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty(nameof(AntoDetalleVentum.ConsProductoNavigation))]
        public virtual ICollection<AntoDetalleVentum> AntoDetalleVenta { get; set; }
        [InverseProperty(nameof(AntoInventario.ConsProductoNavigation))]
        public virtual ICollection<AntoInventario> AntoInventarios { get; set; }
    }
}
