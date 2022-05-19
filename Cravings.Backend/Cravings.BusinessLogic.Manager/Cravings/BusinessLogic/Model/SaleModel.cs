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
    class SaleModel
    {
        #region Members
        public int ConsSale { get; set; }
        public int ConsClient { get; set; }
        public int State { get; set; }
        public DateTime DateRegister { get; set; }
        #endregion
    }
}
