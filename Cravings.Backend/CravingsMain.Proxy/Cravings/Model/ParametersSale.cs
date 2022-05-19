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
    class ParametersSale
    {
        #region Costructors

        public ParametersSale()
        {
        }

        #endregion

        #region Members
        public string ConsVenta { get; set; }
        public string ConsCliente { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        #endregion
    }
}
