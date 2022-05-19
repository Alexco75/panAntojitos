using System;

namespace Cravings.BusinessLogic.Model
{
    /// <summary>
    ///Copyright ©Antojitos - Colombia
    ///Clase Utilizada para cargar parametros definidos en Json.
    ///Autor		:	Alex Castillo Ortiz
    ///Fecha		:	29-Abril-2022
    /// </summary>
    [Serializable()]
    class ParametersInventory
    {
        #region Costructors

        public ParametersInventory()
        {
        }

        #endregion

        #region Members
        public string ConsInventario { get; set; }
        public string ConsProducto { get; set; }
        public string Stock { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        #endregion
    }
}
