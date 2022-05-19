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
    class SaleDetailModel
    {
        #region Members
        public int ConsSale { get; set; }
        public int ConsProduct { get; set; }
        public int Amount { get; set; }
        public int UnitValue { get; set; }
        public int Iva { get; set; }
        public int State { get; set; }
        public DateTime DateRegister { get; set; }
        #endregion
    }
}
