using System;
namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar Información encontrada.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	02-Mayo-2022
    /// </summary>
    [Serializable()]
    public class InventoryModel
    {
        public int ConsInventario { get; set; }
        public int ConsProducto { get; set; }
        public int Stock { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}