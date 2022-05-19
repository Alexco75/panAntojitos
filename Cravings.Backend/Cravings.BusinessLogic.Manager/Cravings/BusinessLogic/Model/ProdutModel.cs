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
    public class ProdutModel
    {
        public int ConsProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitValue { get; set; }
        public int State { get; set; }
        public DateTime DateRegister { get; set; }
    }
}