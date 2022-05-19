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
    class ParametersDetailSale
    {
        #region Costructors

        public ParametersDetailSale()
        {
        }

        #endregion

        #region Members
        public string ConsVenta { get; set; }
        public string ConsProducto { get; set; }
        public string Cantidad { get; set; }
        public string ValorUnitario { get; set; }
        public string Iva { get; set; }
        public string Estado { get; set; }
        #endregion
    }
}
