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
    class ParametersProduct
    {
        private string consProduct;
        #region Costructors

        public ParametersProduct()
        {
        }

        public ParametersProduct(string consProduct, string name, string description, string unitValue, string state)
        {
            this.consProduct = consProduct;
            Nombre = name;
            Descripcion = description;
            ValorUnitario = unitValue;
            Estado = state;
        }

        #endregion

        #region Members
        public string ConsProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ValorUnitario { get; set; }
        public string Estado { get; set; }

        #endregion
    }
}
